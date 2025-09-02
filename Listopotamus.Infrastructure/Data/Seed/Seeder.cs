// <copyright file="Seeder.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Entities.Lookups;
using Microsoft.EntityFrameworkCore;

namespace Listopotamus.Infrastructure.Data.Seed
{
    /// <summary>
    /// Represents the seed data class.
    /// </summary>
    internal class Seeder()
    {
        /// <summary>
        /// The system user name.
        /// </summary>
        private const string SYSTEM = "SYSTEM";

        /// <summary>
        /// Seeds the database.
        /// </summary>
        /// <param name="builder">The model builder.</param>
        public static void SeedData(ModelBuilder builder)
        {
            SeedMartketplaceTypes(builder);
            SeedCategoryTypes(builder);
            SeedLocationTypes(builder);
        }

        /// <summary>
        /// Seeds the marketplace types.
        /// </summary>
        /// <param name="builder">The model builder.</param>
        private static void SeedMartketplaceTypes(ModelBuilder builder)
        {
            builder.Entity<MarketplaceType>().HasData(new List<MarketplaceType>()
            {
                new ()
                {
                    Id = 1,
                    Name = "Ebay",
                    LookupValue = "Ebay",
                    Description = "The Ebay marketplace type.",
                    CreatedBy = SYSTEM,
                    UpdatedBy = SYSTEM,
                },
            });
        }

        /// <summary>
        /// Seeds the category types.
        /// </summary>
        /// <param name="builder">The model builder.</param>
        private static void SeedCategoryTypes(ModelBuilder builder)
        {
            builder.Entity<CategoryType>().HasData(new List<CategoryType>()
            {
                new ()
                {
                    Id = 1,
                    Code = 73943,
                    MarketplaceTypeId = 1,
                    Name = "Gun Parts",
                    LookupValue = "Gun Parts",
                    Description = "The Gun Parts category type.",
                    CreatedBy = SYSTEM,
                    UpdatedBy = SYSTEM,
                },
            });
        }

        /// <summary>
        /// Seeds the location types.
        /// </summary>
        /// <param name="builder">The model builder.</param>
        private static void SeedLocationTypes(ModelBuilder builder)
        {
            builder.Entity<LocationType>().HasData(new List<LocationType>()
            {
                new ()
                {
                    Id = 1,
                    MarketplaceTypeId = 1,
                    Name = "USA",
                    LookupValue = "USA",
                    Description = "The USA location type.",
                    CreatedBy = SYSTEM,
                    UpdatedBy = SYSTEM,
                },
            });
        }
    }
}
