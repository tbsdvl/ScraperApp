using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.ApplicationCore.Services;
using Listopotamus.Infrastructure.Data.Repositories.Identity;
using Listopotamus.Infrastructure.Data.Services;
using Listopotamus.Infrastructure.Data;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AutoMapper;
using Listopotamus.ApplicationCore;
using Listopotamus.Infrastructure.Security.Entities.Identity;
using Listopotamus.Infrastructure.Services;
using Listopotamus.Infrastructure.Data.Repositories.Scraper;
using Listopotamus.Infrastructure.Data.Repositories.Jobs;
using Listopotamus.Infrastructure.Data.Repositories.Lookup;

namespace Listopotamus.Integrations.Test
{
    [TestClass]
    public abstract class BaseUnitTest
    {
        public IServiceProvider ServiceProvider { get; private set; }

        private CosmosClient CosmosClient { get; set; }

        private string DatabaseName { get; set; }

        private string ContainerName { get; set; }

        /// <summary>
        /// Initialize the test.
        /// </summary>
        [TestInitialize]
        public async Task BaseTestInitializeAsync()
        {
            await InitializeAsync();
        }

        public virtual async Task InitializeAsync()
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
            serviceCollection.AddIdentityCore<Infrastructure.Security.Entities.Identity.User>(options =>
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

            // Add distributed cache
            serviceCollection.TryAddTransient<IDistributedCacheService, DistributedCacheService>();

            // Add automapper
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            serviceCollection.AddSingleton(mappingConfig.CreateMapper());

            // Add application services
            serviceCollection.TryAddTransient<IEbayScraperService, EbayScraperService>();
            serviceCollection.TryAddTransient<IBaseScraperService, ScraperService>();
            serviceCollection.TryAddTransient<ISearchQueryRepository, SearchQueryRepository>();
            serviceCollection.TryAddTransient<IUserSearchRepository, UserSearchRepository>();
            serviceCollection.TryAddTransient<IScrapeJobRepository, ScrapeJobRepository>();
            serviceCollection.TryAddTransient<ILookupRepository, LookupRepository>();
            serviceCollection.TryAddTransient<ISearchResultItemRepository, SearchResultItemRepository>();
            serviceCollection.TryAddTransient<IItemRepository, ItemRepository>();
            serviceCollection.TryAddTransient<ISearchQueryService, SearchQueryService>();
            serviceCollection.TryAddTransient<ITaskQueueService, TaskQueueService>();
            serviceCollection.TryAddTransient<ILookupService, LookupService>();
            serviceCollection.TryAddTransient<IItemService, ItemService>();
            serviceCollection.TryAddTransient<ISearchResultItemService, SearchResultItemService>();

            this.ServiceProvider = serviceCollection.BuildServiceProvider();

            var context = this.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            var roleManager = this.ServiceProvider.GetRequiredService<ApplicationRoleManager>();

            var roles = new[] { "Admin", "User" };

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
    }
}
