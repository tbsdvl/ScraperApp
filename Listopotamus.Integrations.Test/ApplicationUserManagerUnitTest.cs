using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.ApplicationCore.Services;
using Listopotamus.Core.Entities.Identity;
using Listopotamus.Infrastructure.Data;
using Listopotamus.Infrastructure.Data.Repositories.Identity;
using Listopotamus.Infrastructure.Data.Services;
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

        [TestInitialize]
        public void Initialize()
        {
            var isLocalDevelopment = string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("BUILD_BUILDID"));

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false);

            // if it is not running in CI pipeline then load the development json file
            if (isLocalDevelopment)
            {
                configuration.AddJsonFile("appsettings.Development.json", true);
            }
            else
            {
                configuration.AddJsonFile("appsettings.Pipeline.json", true);
            }

            var config = configuration.Build();

            var serviceCollection = new ServiceCollection();

            // Add dependencies
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config["ConnectionStrings:DefaultConnection"])); // Or use your actual database configuration

            serviceCollection.AddCosmosCache((CosmosCacheOptions cacheOptions) =>
            {
                cacheOptions.ContainerName = config["DistributedCache:CosmosCacheContainer"];
                cacheOptions.DatabaseName = config["DistributedCache:CosmosCacheDatabase"];
                cacheOptions.ClientBuilder = new CosmosClientBuilder(config["DistributedCache:CosmosConnectionString"]);
                cacheOptions.CreateIfNotExists = true;
            });

            serviceCollection.AddHttpContextAccessor();

            serviceCollection.AddTransient<IUserContextService, UserContextService>(); // Replace with a mock or actual implementation

            serviceCollection.AddLogging();
            serviceCollection.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddUserManager<ApplicationUserManager>();

            serviceCollection.TryAddTransient<IDistributedCacheService, DistributedCacheService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            this.UserManager = serviceProvider.GetRequiredService<ApplicationUserManager>();
        }

        private static User CreateTestUser()
        {
            return new User
            {
                UserName = "testuser",
                Email = "testuser@example.com",
                FirstName = "Test",
                LastName = "User",
                ExternalId = Guid.NewGuid(),
                NotificationsEnabled = true,
                UpdatedBy = "system",
                UpdatedDate = DateTime.UtcNow,
                UserObjectId = Guid.NewGuid().ToString(),
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
            await this.UserManager.CreateAsync(user, password, new[] { "User" });

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
