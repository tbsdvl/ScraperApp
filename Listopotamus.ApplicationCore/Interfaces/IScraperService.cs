// <copyright file="IScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using HtmlAgilityPack;
using Listopotamus.ApplicationCore.DTOs;

namespace Listopotamus.ApplicationCore.Interfaces
{
    /// <summary>
    /// Represents the scraper service interface.
    /// </summary>
    public interface IScraperService
    {
        /// <summary>
        /// Gets the items list node path.
        /// </summary>
        public string ItemsListNodePath { get; }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <param name="request">The scraper request.</param>
        /// <returns>The URL.</returns>
        string GetUrl(SearchCriteriaModel request);

        /// <summary>
        /// Gets a list of items from HTML nodes.
        /// </summary>
        /// <param name="searchQueryId">The search query id.</param>
        /// <param name="searchCriteriaModel">The search criteria model.</param>
        /// <param name="nodes">The list of HTML nodes.</param>
        /// <returns>A list of items.</returns>
        Task<List<ItemDto>> GetItemsAsync(long? searchQueryId, SearchCriteriaModel searchCriteriaModel, List<HtmlNode> nodes);
    }
}
