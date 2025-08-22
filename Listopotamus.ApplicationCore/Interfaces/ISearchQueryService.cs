// <copyright file="ISearchQueryService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.DTOs;

namespace Listopotamus.ApplicationCore.Interfaces
{
    /// <summary>
    /// Represents an interface for the search query service.
    /// </summary>
    public interface ISearchQueryService
    {
        /// <summary>
        /// Creates a search query.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <returns>The search query.</returns>
        Task CreateAsync(SearchCriteriaModel searchCriteria);
    }
}
