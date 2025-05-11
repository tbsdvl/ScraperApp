using Microsoft.EntityFrameworkCore;
using Listopotamus.ApplicationCore;
using Listopotamus.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Caching.Distributed;

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

// Add the Cosmos DB cache
builder.Services.AddCosmosCache((CosmosCacheOptions cacheOptions) =>
{
    cacheOptions.ContainerName = builder.Configuration["DistributedCache:CosmosCacheContainer"];
    cacheOptions.DatabaseName = builder.Configuration["DistributedCache:CosmosCacheDatabase"];
    cacheOptions.ClientBuilder = new CosmosClientBuilder(builder.Configuration["DistributedCache:CosmosConnectionString"]);
    cacheOptions.CreateIfNotExists = true;
});

// Add Identity
builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapIdentityApi<IdentityUser>();

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