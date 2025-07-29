// <copyright file="IBaseScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.DTOs;

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
        /// <param name="request">The scraper request.</param>
        /// <returns>A list of items.</returns>
        Task<ScraperResponse> GetItemsAsync(ScraperRequest request);
    }
}
