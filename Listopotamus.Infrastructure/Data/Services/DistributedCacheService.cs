// <copyright file="DistributedCacheService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Entities.Identity;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Listopotamus.Infrastructure.Data.Services
{
    /// <summary>
    /// Represents the distributed cache service.
    /// </summary>
    public class DistributedCacheService : IDistributedCacheService
    {
        private readonly IDistributedCache DistributedCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistributedCacheService"/> class.
        /// </summary>
        /// <param name="cache">The distributed cache instance.</param>
        public DistributedCacheService(IDistributedCache cache)
        {
            DistributedCache = cache;
        }

        /// <summary>
        /// Generates a cache key for a user based on their object ID.
        /// </summary>
        /// <param name="objectId">The object ID of the user.</param>
        /// <returns>The cache key.</returns>
        private static string GetCacheKeyForUser(string objectId)
        {
            return $"User:{objectId}";
        }

        /// <inheritdoc />
        public async Task<User?> FindUserByObjectIdAsync(string objectId)
        {
            var cacheKey = GetCacheKeyForUser(objectId);

            var cachedUser = await this.DistributedCache.GetStringAsync(cacheKey);

            if (string.IsNullOrEmpty(cachedUser))
            {
                return null;
            }

            return JsonSerializer.Deserialize<User>(cachedUser);
        }

        /// <inheritdoc />
        public async Task CacheUserAsync(User user, TimeSpan expiration)
        {
            var cacheKey = GetCacheKeyForUser(user.UserObjectId);

            var serializedUser = JsonSerializer.Serialize(user);

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration
            };

            await this.DistributedCache.SetStringAsync(cacheKey, serializedUser, options);
        }

        /// <inheritdoc />
        public async Task ClearUserCacheAsync(string objectId)
        {
            var cacheKey = GetCacheKeyForUser(objectId);
            await this.DistributedCache.RemoveAsync(cacheKey);
        }
    }
}