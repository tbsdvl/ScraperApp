// <copyright file="ISearchResultItemService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.Core.Entities.Items;

namespace Listopotamus.ApplicationCore.Interfaces
{
    /// <summary>
    /// Represents the search result item service interface.
    /// </summary>
    public interface ISearchResultItemService
    {
        /// <summary>
        /// Creates a list of search result items.
        /// </summary>
        /// <param name="searchQueryId">The search query id.</param>
        /// <param name="savedItems">The list of saved items.</param>
        /// <returns>The list of search result items.</returns>
        Task CreateAsync(long searchQueryId, List<Item> savedItems);
    }
}
