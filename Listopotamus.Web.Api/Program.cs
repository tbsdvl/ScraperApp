using Microsoft.EntityFrameworkCore;
using Listopotamus.ApplicationCore;
using Listopotamus.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Caching.Distributed;
using Listopotamus.Infrastructure.Data.Repositories.Identity;
using Listopotamus.Infrastructure.Security.Entities.Identity;
using Listopotamus.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.ApplicationCore.Services;
using Listopotamus.Infrastructure.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add the Cosmos DB cache
builder.Services.AddCosmosCache((CosmosCacheOptions cacheOptions) =>
{
    cacheOptions.ContainerName = builder.Configuration["DistributedCache:CosmosCacheContainer"];
    cacheOptions.DatabaseName = builder.Configuration["DistributedCache:CosmosCacheDatabase"];
    cacheOptions.ClientBuilder = new CosmosClientBuilder(builder.Configuration["DistributedCache:CosmosConnectionString"]);
    cacheOptions.CreateIfNotExists = true;
});

// add services?
builder.Services.AddScoped<IUserContextService, UserContextService>();

// Add Identity
builder.Services.AddAuthorization();
builder.Services.TryAddScoped<IRoleValidator<Role>, RoleValidator<Role>>();
builder.Services.TryAddScoped<RoleManager<Role>>();
builder.Services.TryAddScoped<SignInManager<User>>();
builder.Services
    .AddIdentityCore<User>()
     .AddUserStore<ApplicationUserStore<ApplicationDbContext>>()
    .AddRoles<Role>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddUserManager<ApplicationUserManager>()
    .AddRoleManager<ApplicationRoleManager>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IDistributedCacheService, DistributedCacheService>();

var app = builder.Build();

// Inser roles into the database
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    var roles = UserRoles.GetAll();

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            var newRole = new Role()
            {
                Name = role,
                NormalizedName = role.ToUpper()
            };
            await roleManager.CreateAsync(newRole);
        }
    }
}


// Use distributed cache
app.Lifetime.ApplicationStarted.Register(() =>
{
    var currentTimeUTC = DateTime.UtcNow.ToString();
    byte[] encodedCurrentTimeUTC = System.Text.Encoding.UTF8.GetBytes(currentTimeUTC);
    var options = new DistributedCacheEntryOptions()
        .SetSlidingExpiration(TimeSpan.FromSeconds(20));
    var distributedCache = app.Services.GetService<IDistributedCache>();
    if (distributedCache != null)
    {
        distributedCache.Set("cachedTimeUTC", encodedCurrentTimeUTC, options);
    }
    else
    {
        Console.WriteLine("IDistributedCache service is not available.");
    }
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();