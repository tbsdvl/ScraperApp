using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.ApplicationCore.Services;
using Listopotamus.Core.Entities.Identity;
using Listopotamus.Infrastructure.Data;
using Listopotamus.Infrastructure.Data.Repositories.Identity;
using Listopotamus.Infrastructure.Data.Services;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Listopotamus.Integrations.Test
{
    [TestClass]
    public sealed class ApplicationUserManagerIntegrationTest
    {
        private ApplicationUserManager UserManager { get; set; }

        private CosmosClient CosmosClient { get; set; }

        private string DatabaseName { get; set; }

        private string ContainerName { get; set; }

        [TestInitialize]
        public async Task Initialize()
        {
            var isLocalDevelopment = string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("BUILD_BUILDID"));
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false);

            if (isLocalDevelopment)
            {
                configuration.AddJsonFile("appsettings.Development.json", true);
            }
            else
            {
                configuration.AddJsonFile("appsettings.Pipeline.json", true);
            }

            var config = configuration.Build();

            this.ContainerName = Guid.NewGuid().ToString();
            this.CosmosClient = new CosmosClientBuilder(config["DistributedCache:CosmosConnectionString"])
                .WithConnectionModeDirect()
                .Build();

            this.DatabaseName = config["DistributedCache:CosmosCacheDatabase"];
            var database = await this.CosmosClient.CreateDatabaseIfNotExistsAsync(config["DistributedCache:CosmosCacheDatabase"]);
            await database.Database.CreateContainerIfNotExistsAsync(
                new ContainerProperties
                {
                    Id = this.ContainerName,
                    PartitionKeyPath = "/id"
                });

            var serviceCollection = new ServiceCollection();
            serviceCollection.RemoveAll<DbContextOptions<ApplicationDbContext>>();
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);
            });

            serviceCollection.AddCosmosCache((CosmosCacheOptions cacheOptions) =>
            {
                cacheOptions.ContainerName = this.ContainerName;
                cacheOptions.DatabaseName = config["DistributedCache:CosmosCacheDatabase"];
                cacheOptions.ClientBuilder = new CosmosClientBuilder(config["DistributedCache:CosmosConnectionString"]);
                cacheOptions.CreateIfNotExists = true;
            });

            serviceCollection.AddHttpContextAccessor();
            serviceCollection.AddTransient<IUserContextService, UserContextService>();
            serviceCollection.AddLogging();
            serviceCollection.AddIdentityCore<Core.Entities.Identity.User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddUserManager<ApplicationUserManager>()
            .AddRoleManager<ApplicationRoleManager>();

            serviceCollection.TryAddTransient<IDistributedCacheService, DistributedCacheService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            this.UserManager = serviceProvider.GetRequiredService<ApplicationUserManager>();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            var userManager = serviceProvider.GetRequiredService<ApplicationUserManager>();
            var roleManager = serviceProvider.GetRequiredService<ApplicationRoleManager>();

            // Define roles to seed
            var roles = new[] { "Admin", "User" };

            // Seed roles
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var newRole = new Role
                    {
                        Name = role,
                        NormalizedName = role.ToUpperInvariant(),
                    };
                    await roleManager.CreateAsync(newRole);
                }
            }
        }

        [TestCleanup]
        public async Task TestCleanup()
        {
            if (this.CosmosClient is not null)
            {
                var container = this.CosmosClient.GetContainer(this.DatabaseName, this.ContainerName);
                await container.DeleteContainerAsync();
            }

            this.CosmosClient?.Dispose();
        }

        private static Core.Entities.Identity.User CreateTestUser()
        {
            return new Core.Entities.Identity.User
            {
                UserName = "testuser",
                Email = "testuser@example.com",
                FirstName = "Test",
                LastName = "User",
                NotificationsEnabled = true,
                UpdatedBy = "system",
                UpdatedDate = DateTime.UtcNow,
                UserObjectId = Guid.NewGuid().ToString(),
                ExternalId = Guid.NewGuid(),
            };
        }

        [TestMethod]
        public async Task CreateUser_Succeeds()
        {
            // Arrange
            var user = CreateTestUser();
            var password = "Test@123";
            var roles = new[] { "Admin", "User" };

            // Act
            var result = await this.UserManager.CreateAsync(user, password, roles);

            // Assert
            Assert.IsTrue(result.Succeeded, "Failed to create user.");

            if (!string.IsNullOrWhiteSpace(user.UserName))
            {
                var createdUser = await this.UserManager.FindAsync(user.UserName);
                Assert.IsNotNull(createdUser, "User was not found after creation.");
                Assert.AreEqual(user.Email, createdUser.Email, "User email does not match.");
            }
        }

        [TestMethod]
        public async Task UpdateUser_Succeeds()
        {
            // Arrange
            var user = CreateTestUser();
            var password = "Test@123";
            var roles = new[] { "Admin" };
            await this.UserManager.CreateAsync(user, password, roles);

            // Act
            user.FirstName = "Updated";
            user.LastName = "User";
            var updatedRoles = new[] { "User" };
            var result = await this.UserManager.UpdateAsync(user, updatedRoles);

            // Assert
            Assert.IsTrue(result.Succeeded, "Failed to update user.");

            if (!string.IsNullOrWhiteSpace(user.UserName))
            {
                var updatedUser = await this.UserManager.FindAsync(user.UserName);
                Assert.IsNotNull(updatedUser, "User was not found after update.");
                Assert.AreEqual(user.FirstName, updatedUser.FirstName, "User first name does not match.");
                Assert.AreEqual(user.LastName, updatedUser.LastName, "User last name does not match.");
            }
        }

        [TestMethod]
        public async Task FindUserById_Succeeds()
        {
            // Arrange
            var user = CreateTestUser();
            var password = "Test@123";
            var result = await this.UserManager.CreateAsync(user, password, new[] { "User" });

            // Act
            var foundUser = await this.UserManager.FindAsync(user.Id);

            // Assert
            Assert.IsNotNull(foundUser, "User was not found by ID.");
            Assert.AreEqual(user.UserName, foundUser.UserName, "Usernames do not match.");
        }

        [TestMethod]
        public async Task FindUserByExternalId_Succeeds()
        {
            // Arrange
            var user = CreateTestUser();
            var password = "Test@123";
            await this.UserManager.CreateAsync(user, password, new[] { "User" });

            // Act
            var foundUser = await this.UserManager.FindAsync(user.ExternalId.Value);

            // Assert
            Assert.IsNotNull(foundUser, "User was not found by external ID.");
            Assert.AreEqual(user.UserName, foundUser.UserName, "Usernames do not match.");
        }

        [TestMethod]
        public async Task ClearUserCache_Succeeds()
        {
            // Arrange
            var user = CreateTestUser();
            var password = "Test@123";
            await this.UserManager.CreateAsync(user, password, new[] { "User" });

            // Act
            await this.UserManager.ClearUserCacheAsync(user.ExternalId.ToString());

            // Assert
            var cachedUser = await this.UserManager.FindUserByObjectIdAsync(user.ExternalId.ToString());
            Assert.IsNull(cachedUser, "User cache was not cleared.");
        }
    }
}
