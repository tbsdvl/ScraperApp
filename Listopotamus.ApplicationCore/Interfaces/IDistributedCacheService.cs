// <copyright file="IDistributedCacheService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.Infrastructure.Security.Entities.Identity;

namespace Listopotamus.Infrastructure.Data.Services
{
    /// <summary>
    /// Represents the interface for the distributed cache service.
    /// </summary>
    public interface IDistributedCacheService
    {
        /// <summary>
        /// Finds a user by their object ID in the distributed cache.
        /// </summary>
        /// <param name="objectId">The object ID of the user.</param>
        /// <returns>The user if found, otherwise null.</returns>
        Task<User?> FindUserByObjectIdAsync(string objectId);

        /// <summary>
        /// Caches a user by their object ID.
        /// </summary>
        /// <param name="user">The user to cache.</param>
        /// <param name="expiration">The cache expiration time.</param>
        /// <returns>A <see cref="Task"/> representing the clearing of the user.</returns>
        Task CacheUserAsync(User user, TimeSpan expiration);

        /// <summary>
        /// Clears the cached user by their object ID.
        /// </summary>
        /// <param name="objectId">The object ID of the user to clear from the cache.</param>
        /// <returns>A <see cref="Task"/> representing the clearing of the user's cache.</returns>
        Task ClearUserCacheAsync(string objectId);
    }
}
