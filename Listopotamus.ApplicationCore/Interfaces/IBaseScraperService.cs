// <copyright file="IBaseScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.DTOs;
using Listopotamus.Core;

namespace Listopotamus.ApplicationCore.Interfaces
{
    /// <summary>
    /// Represents the base scraper service interface.
    /// </summary>
    public interface IBaseScraperService
    {
        /// <summary>
        /// Gets a list of items from HTML nodes.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <returns>A list of items.</returns>
        Task<Result<List<ItemDto>>> GetItemsAsync(SearchCriteriaModel searchCriteria);
    }
}
