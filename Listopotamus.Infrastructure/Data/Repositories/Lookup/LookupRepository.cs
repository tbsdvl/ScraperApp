// <copyright file="LookupRepository.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Entities;
using Listopotamus.ApplicationCore.Entities.Lookups;
using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Infrastructure.Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Listopotamus.Infrastructure.Data.Repositories.Lookup
{
    /// <summary>
    /// Represents the lookup repository.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="LookupRepository"/> class.
    /// </remarks>
    /// <param name="context">The application database context.</param>
    public class LookupRepository(ApplicationDbContext context) : GenericRepository<BaseLookupEntity, int>(context), ILookupRepository
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        public ApplicationDbContext Context { get; } = context;

        /// <summary>
        /// Gets the category types.
        /// </summary>
        /// <returns>The list of category types.</returns>
        public async Task<List<CategoryType>> GetCategoryTypesAsync()
        {
            return await this.Context.CategoryTypes.ToListAsync();
        }
    }
}
