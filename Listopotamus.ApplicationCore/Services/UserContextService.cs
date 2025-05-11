// <copyright file="UserContextService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Shared.Extensions;
using Microsoft.AspNetCore.Http;

namespace Listopotamus.ApplicationCore.Services
{
    /// <summary>
    /// Represents the user context service.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="UserContextService"/> class.
    /// </remarks>
    /// <param name="httpContextAccessor">The http context accessor.</param>
    public class UserContextService(IHttpContextAccessor httpContextAccessor) : IUserContextService
    {
        /// <summary>
        /// Gets the HTTP context accessor.
        /// </summary>
        private IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;

        /// <summary>
        /// Gets the user id from the HTTP context.
        /// </summary>
        /// <returns>The user object id.</returns>
        public string GetUserId()
        {
            return this.HttpContextAccessor.HttpContext.User.Claims.GetUserObjectId();
        }
    }
}
