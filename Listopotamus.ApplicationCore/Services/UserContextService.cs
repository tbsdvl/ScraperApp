// <copyright file="UserContextService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Core.Extensions;
using Microsoft.AspNetCore.Http;

namespace Listopotamus.ApplicationCore.Services
{
    /// <summary>
    /// Represents the user context service.
    /// </summary>
    public class UserContextService : IUserContextService
    {
        /// <summary>
        /// Gets the HTTP context accessor.
        /// </summary>
        private IHttpContextAccessor HttpContextAccessor { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserContextService"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">The http context accessor.</param>
        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            this.HttpContextAccessor = httpContextAccessor;
        }

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
