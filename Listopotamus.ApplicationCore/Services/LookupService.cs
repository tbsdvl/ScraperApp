// <copyright file="LookupService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Entities.Lookups;
using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Core;

namespace Listopotamus.ApplicationCore.Services
{
    /// <summary>
    /// Represents the lookup service.
    /// </summary>
    /// <param name="lookupRepository">The lookup repository.</param>
    public class LookupService(ILookupRepository lookupRepository) : ILookupService
    {
        /// <summary>
        /// Gets the lookup repository.
        /// </summary>
        public ILookupRepository LookupRepository { get; } = lookupRepository;

        /// <summary>
        /// Gets the category types.
        /// </summary>
        /// <returns>The list of category types.</returns>
        public async Task<Result<List<CategoryType>>> GetCategoryTypesAsync()
        {
            var types = await this.LookupRepository.GetCategoryTypesAsync();
            return Result<List<CategoryType>>.Success(types);
        }
    }
}
