using Listopotamus.ApplicationCore.DTOs;
using Listopotamus.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Listopotamus.Web.Api.Areas.Controllers
{
    /// <summary>
    /// Represents the scraper controller.
    /// </summary>
    [Area("Scraper")]
    [Route("api/[area]/[controller]")]
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
        /// <param name="request">The request.</param>
        /// <returns>The list of found results.</returns>
        [HttpPost]
        public async Task<IActionResult> Search([FromBody] ScraperRequest request)
        {
            var results = await this.ScraperService.GetItemsAsync(request);
            return Ok(results);
        }
    }
}
