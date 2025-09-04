// <copyright file="IApplicationUserManager.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.Infrastructure.Security.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Listopotamus.Infrastructure.Data.Repositories.Identity
{
    /// <summary>
    /// Represents the interface for the application user manager.
    /// </summary>
    public interface IApplicationUserManager
    {
        /// <summary>
        /// Adds a new user and assigns roles to them.
        /// </summary>
        /// <param name="user">The user to add.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="roles">The roles to assign to the user.</param>
        /// <returns>The result of the operation.</returns>
        Task<IdentityResult> CreateAsync(User user, string password, IEnumerable<string> roles);

        /// <summary>
        /// Updates an existing user and their roles.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <param name="roles">The updated roles for the user.</param>
        /// <returns>The result of the operation.</returns>
        Task<IdentityResult> UpdateAsync(User user, IEnumerable<string> roles);

        /// <summary>
        /// Finds a user by their name.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <returns>The user if found, otherwise null.</returns>
        Task<User?> FindAsync(string name);

        /// <summary>
        /// Finds a user by their numeric ID.
        /// </summary>
        /// <param name="id">The numeric ID of the user.</param>
        /// <returns>The user if found, otherwise null.</returns>
        Task<User?> FindAsync(int id);

        /// <summary>
        /// Finds a user by their external ID.
        /// </summary>
        /// <param name="externalId">The external ID of the user.</param>
        /// <returns>The user if found, otherwise null.</returns>
        Task<User?> FindAsync(Guid externalId);

        /// <summary>
        /// Finds the user by their object ID.
        /// </summary>
        /// <param name="objectId">The user's object ID.</param>
        /// <returns>The user if found, otherwise null.</returns>
        Task<User?> FindUserByObjectIdAsync(string objectId);

        /// <summary>
        /// Clears the user's cache.
        /// </summary>
        /// <param name="objectId">The user's object ID.</param>
        /// <returns>A <see cref="Task"/> representing the clearing of the user cache.</returns>
        Task ClearUserCacheAsync(string objectId);
    }
}
