// <copyright file="IScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using HtmlAgilityPack;
using ScraperApp.ApplicationCore.Models;

namespace ScraperApp.ApplicationCore.Interfaces
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
        string GetUrl(ScraperRequest request);

        /// <summary>
        /// Gets an items list node path based on the query options type.
        /// </summary>
        /// <param name="queryOptionsTypeId">The query options type id.</param>
        /// <returns>The items list node path.</returns>
        string GetItemsListNodePath(int queryOptionsTypeId);

        /// <summary>
        /// Gets a list of items from HTML nodes.
        /// </summary>
        /// <param name="request">The scraper request.</param>
        /// <param name="nodes">The list of HTML nodes.</param>
        /// <returns>A list of items.</returns>
        List<ItemModel> GetItems(ScraperRequest request, List<HtmlNode> nodes);
    }
}
