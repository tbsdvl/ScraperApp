using Listopotamus.Infrastructure.Security.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Listopotamus.Web.Api.Areas.Controllers
{
    /// <summary>
    /// Represents the scraper controller.
    /// </summary>
    [Authorize]
    [Route("")]
    public class IdentityController : ControllerBase
    {
        private SignInManager<User> SignInManager { get; }

        /// <summary>
        /// Initializes a new scraper controller.
        /// </summary>
        /// <param name="signInManager">The sign in manager.</param>
        public IdentityController(SignInManager<User> signInManager)
        {
            this.SignInManager = signInManager;
        }

        /// <summary>
        /// Logs out the current user.
        /// </summary>
        /// <param name="empty">Empty body parameter.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout([FromBody] object empty)
        {
            if (empty != null)
            {
                await this.SignInManager.SignOutAsync();
                return Ok();
            }
            return Unauthorized();
        }
    }
}