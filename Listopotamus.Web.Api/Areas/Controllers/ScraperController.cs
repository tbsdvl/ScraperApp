using Listopotamus.ApplicationCore.DTOs;
using Listopotamus.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Listopotamus.Web.Api.Areas.Controllers
{
    /// <summary>
    /// Represents the scraper controller.
    /// </summary>
    [Area("Scraper")]
    [Route("api/[area]")]
    public class ScraperController : ControllerBase
    {
        private IBaseScraperService ScraperService { get; }

        /// <summary>
        /// Initializes a new scraper controller.
        /// <param name="scraperService">The scraper service.</param>
        /// </summary>
        public ScraperController(
            IBaseScraperService scraperService
        )
        {
            this.ScraperService = scraperService;
        }

        /// <summary>
        /// Searches for items based on a search keyword.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <returns>The list of found results.</returns>
        [HttpPost]
        public async Task<IActionResult> Search(SearchCriteriaModel searchCriteria)
        {
            var results = await this.ScraperService.GetItemsAsync(searchCriteria);
            return Ok(results);
        }
    }
}
