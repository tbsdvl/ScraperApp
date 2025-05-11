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
        string GetUrl(ScraperRequest request);

        /// <summary>
        /// Gets a list of items from HTML nodes.
        /// </summary>
        /// <param name="request">The scraper request.</param>
        /// <param name="nodes">The list of HTML nodes.</param>
        /// <returns>A list of items.</returns>
        List<ItemDto> GetItems(ScraperRequest request, List<HtmlNode> nodes);
    }
}
