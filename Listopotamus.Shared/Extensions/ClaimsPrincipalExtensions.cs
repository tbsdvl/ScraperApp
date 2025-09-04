// <copyright file="ClaimsPrincipalExtensions.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.Security.Claims;

namespace Listopotamus.Shared.Extensions
{
    /// <summary>
    /// Represents the claims principal extensions.
    /// </summary>
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Gets the user object id from the claims.
        /// </summary>
        /// <param name="claims">The user claims.</param>
        /// <returns>The user id.</returns>
        public static Guid GetUserId(this IEnumerable<Claim>? claims)
        {
            if (claims is null)
            {
                return Guid.Empty;
            }

            var id = claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            
            if (id is null)
            {
                return Guid.Empty;
            }

            return Guid.Parse(id.Value);
        }

        /// <summary>
        /// Gets the user id from the claims principal.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The user id.</returns>
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            if (user is null)
            {
                return Guid.Empty;
            }

            return user.Claims.GetUserId();
        }
    }
}
