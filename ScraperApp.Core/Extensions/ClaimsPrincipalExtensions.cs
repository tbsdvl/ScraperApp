// <copyright file="ClaimsPrincipalExtensions.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.Security.Claims;

namespace ScraperApp.Core.Extensions
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
        /// <returns>The user object id.</returns>
        public static string GetUserObjectId(this IEnumerable<Claim>? claims)
        {
            if (claims is null)
            {
                return string.Empty;
            }

            var id = claims.FirstOrDefault(c =>
                c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier" ||
                c.Type == "oid"
            );
            
            if (id is null)
            {
                return string.Empty;
            }

            return id.Value;
        }

        /// <summary>
        /// Gets the user object id from the claims principal.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The user object id.</returns>
        public static string GetUserObjectId(this ClaimsPrincipal user)
        {
            if (user is null)
            {
                return string.Empty;
            }

            return user.Claims.GetUserObjectId();
        }
    }
}
