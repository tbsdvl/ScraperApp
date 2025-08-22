// <copyright file="ScraperController.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.DTOs;
using Listopotamus.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Listopotamus.Web.Api.Areas.Controllers
{
    /// <summary>
    /// Represents the scraper controller.
    /// </summary>
    [Authorize]
    [Area("Scraper")]
    [Route("api/[area]")]
    public class ScraperController : ControllerBase
    {
        private IBaseScraperService ScraperService { get; }

        private ISearchQueryService SearchQueryService { get; }

        /// <summary>
        /// Initializes a new scraper controller.
        /// <param name="scraperService">The scraper service.</param>
        /// <param name="searchQueryService">The search query service.</param>
        /// </summary>
        public ScraperController(
            IBaseScraperService scraperService,
            ISearchQueryService searchQueryService
        )
        {
            this.ScraperService = scraperService;
            this.SearchQueryService = searchQueryService;
        }

        /// <summary>
        /// Searches for items based on a search keyword.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <returns>The list of found results.</returns>
        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SearchCriteriaModel searchCriteria)
        {
            await this.SearchQueryService.CreateAsync(searchCriteria);
            return Ok();
        }
    }
}
