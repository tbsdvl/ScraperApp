// <copyright file="ApplicationDbContext.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Core.Entities;
using Listopotamus.Core.Entities.Identity;
using Listopotamus.Core.Entities.Items;
using Listopotamus.Core.Entities.Lookups;
using Listopotamus.Core.Entities.Search;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Listopotamus.Infrastructure.Data
{
    /// <summary>
    /// Represents the application database context.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class with the specified options and user context service.
    /// </remarks>
    /// <param name="options">The db context options.</param>
    /// <param name="userContextService">The user context service.</param>
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUserContextService userContextService) : IdentityDbContext<User, Role, int>(options)
    {
        /// <summary>
        /// The system user name.
        /// </summary>
        private const string SYSTEM = "SYSTEM";

        /// <summary>
        /// The default external id index name.
        /// </summary>
        private const string DefaultExternalIdIndex = "UCX_ExternalId";

        /// <summary>
        /// The default lookup value index name.
        /// </summary>
        private const string DefaultLookupValueIndex = "UCX_LookupValue";

        /// <summary>
        /// Gets or sets the marketplace types.
        /// </summary>
        public DbSet<MarketplaceType> MarketplaceTypes { get; set; }

        /// <summary>
        /// Gets or sets the category types.
        /// </summary>
        public DbSet<CategoryType> CategoryTypes { get; set; }

        /// <summary>
        /// Gets or sets the location types.
        /// </summary>
        public DbSet<LocationType> LocationTypes { get; set; }

        /// <summary>
        /// Gets or sets the user searches.
        /// </summary>
        public DbSet<UserSearch> UserSearches { get; set; }

        /// <summary>
        /// Gets or sets the search queries.
        /// </summary>
        public DbSet<SearchQuery> SearchQueries { get; set; }

        /// <summary>
        /// Gets or sets the search result items.
        /// </summary>
        public DbSet<SearchResultItem> SearchResultItems { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public DbSet<Item> Items { get; set; }

        /// <summary>
        /// Gets the user context service.
        /// </summary>
        private IUserContextService UserContextService { get; } = userContextService;

        /// <summary>
        /// Saves changes to the database asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing saving the entity.</returns>
        public async Task<int> SaveChangesAsync()
        {
            var currentDate = DateTime.Now;
            var userName = this.UserContextService.GetUserId() ?? SYSTEM;

            foreach (var entry in this.ChangeTracker
                         .Entries()
                         .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                var isAdded = entry.State == EntityState.Added;

                SetIfExists(entry, "UpdatedDate", currentDate);
                SetIfExists(entry, "UpdatedBy", userName);

                if (isAdded)
                {
                    SetIfExists(entry, "CreatedDate", currentDate);
                    SetIfExists(entry, "CreatedBy", userName);
                }
                else
                {
                    MarkUnmodified(entry, "CreatedDate");
                    MarkUnmodified(entry, "CreatedBy");
                }
            }

            return await base.SaveChangesAsync();
        }

        /// <summary>
        /// Configures the model for the application database context.
        /// </summary>
        /// <param name="builder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var entityTypes = builder.Model.GetEntityTypes();

            RenameTablesAndIds(builder, entityTypes);

            // add external id index to user
            builder.Entity<User>()
                .HasIndex(x => x.ExternalId)
                .IsUnique()
                .HasDatabaseName(DefaultExternalIdIndex);

            AddExternalIndexes(builder, entityTypes);
            AddLookupIndexes(builder, entityTypes);

            // turn off cascading deletes
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }
        }

        /// <summary>
        /// Renames tables and primary key columns to match the entity CLR names.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="entityTypes">The collection of entity types.</param>
        private static void RenameTablesAndIds(ModelBuilder builder, IEnumerable<Microsoft.EntityFrameworkCore.Metadata.IMutableEntityType> entityTypes)
        {
            foreach (var entity in entityTypes)
            {
                var tableName = entity.ClrType.Name;
                builder.Entity(entity.ClrType).ToTable(tableName);

                var pk = entity.FindPrimaryKey();
                if (pk is not null && pk.Properties.Count == 1)
                {
                    var pkProp = pk.Properties[0];
                    if (pkProp is not null && pkProp.Name.Equals("Id"))
                    {
                        var newPkName = tableName + "Id";
                        pkProp.SetColumnName(newPkName);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the value of a property if it exists in the entity.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The value.</param>
        private static void SetIfExists(EntityEntry entry, string propertyName, object value)
        {
            if (HasProperty(entry, propertyName))
            {
                entry.Property(propertyName).CurrentValue = value;
            }
        }

        /// <summary>
        /// Marks a property as unmodified if it exists in the entity.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <param name="propertyName">The property name.</param>
        private static void MarkUnmodified(EntityEntry entry, string propertyName)
        {
            if (HasProperty(entry, propertyName))
            {
                entry.Property(propertyName).IsModified = false;
            }
        }

        /// <summary>
        /// Checks if a property exists in the entity.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <param name="propertyName">The property name.</param>
        /// <returns>A value indicating whether or not the entry has a property.</returns>
        private static bool HasProperty(EntityEntry entry, string propertyName)
        {
            return entry.Metadata.FindProperty(propertyName) != null;
        }

        /// <summary>
        /// Adds external indexes to the external entity types.
        /// </summary>
        /// <param name="builder">The model builder.</param>
        /// <param name="entityTypes">The collection of entity types.</param>
        private static void AddExternalIndexes(ModelBuilder builder, IEnumerable<Microsoft.EntityFrameworkCore.Metadata.IMutableEntityType> entityTypes)
        {
            foreach (var entityType in entityTypes)
            {
                var clrType = entityType.ClrType;
                if (clrType.BaseType is not null &&
                    clrType.BaseType.IsGenericType &&
                    clrType.BaseType.GetGenericTypeDefinition() == typeof(BaseExternalEntity<>))
                {
                    var entityBuilder = builder.Entity(clrType);

                    entityBuilder.HasIndex("ExternalId")
                        .IsUnique()
                        .HasDatabaseName(DefaultExternalIdIndex);
                }
            }
        }

        /// <summary>
        /// Adds lookup indexes to the lookup entity types.
        /// </summary>
        /// <param name="builder">The model builder.</param>
        /// <param name="entityTypes">The collection of entity types.</param>
        private static void AddLookupIndexes(ModelBuilder builder, IEnumerable<Microsoft.EntityFrameworkCore.Metadata.IMutableEntityType> entityTypes)
        {
            foreach (var entityType in entityTypes)
            {
                var clrType = entityType.ClrType;
                if (clrType.BaseType is not null && clrType.BaseType == typeof(BaseLookupEntity))
                {
                    var entityBuilder = builder.Entity(clrType);

                    entityBuilder.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName(DefaultLookupValueIndex);
                }
            }
        }
    }
}
