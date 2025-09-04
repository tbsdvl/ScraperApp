// <copyright file="ILookupRepository.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Entities;
using Listopotamus.ApplicationCore.Entities.Lookups;

namespace Listopotamus.ApplicationCore.Interfaces
{
    /// <summary>
    /// Represents the interface for the lookup repository.
    /// </summary>
    public interface ILookupRepository : IGenericRepository<BaseLookupEntity, int>
    {
        /// <summary>
        /// Gets the category types.
        /// </summary>
        /// <returns>The list of category types.</returns>
        Task<List<CategoryType>> GetCategoryTypesAsync();
    }
}
