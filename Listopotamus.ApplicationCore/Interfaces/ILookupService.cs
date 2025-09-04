// <copyright file="ILookupService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Entities.Lookups;
using Listopotamus.Core;

namespace Listopotamus.ApplicationCore.Interfaces
{
    /// <summary>
    /// Represents the interface for the lookup service.
    /// </summary>
    public interface ILookupService
    {
        /// <summary>
        /// Gets the category types.
        /// </summary>
        /// <returns>The list of category types.</returns>
        Task<Result<List<CategoryType>>> GetCategoryTypesAsync();
    }
}
