// <copyright file="ApplicationUserManager.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Entities.Identity;
using Listopotamus.Infrastructure.Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Listopotamus.Infrastructure.Data.Repositories.Identity
{
    /// <summary>
    /// Represents the application user manager.
    /// </summary>
    public class ApplicationUserManager : UserManager<User>
    {
        /// <summary>
        /// Gets the distributed cache service.
        /// </summary>
        private IDistributedCacheService DistributedCacheService { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserManager"/> class.
        /// </summary>
        /// <param name="store">The persistence store the manager will operate over.</param>
        /// <param name="optionsAccessor">The accessors used to access the IdentityOptions.</param>
        /// <param name="passwordHasher">The password hashing implementation to use when saving passwords.</param>
        /// <param name="userValidators">A collection of user validators to validate the user against.</param>
        /// <param name="passwordValidators">A collection of IPasswordValidator to validate passwords against.</param>
        /// <param name="keyNormalizer">The LookupNormalizer to use when generating index keys for users.</param>
        /// <param name="errors">The Microsoft.AspNetCore.Identity.IdentityErrorDescriber used to provider error messages.</param>
        /// <param name="services">The System.IServiceProvider used to resolve services.</param>
        /// <param name="logger">The logger used to log messages, warnings and errors.</param>
        /// <param name="cacheService">The cache service.</param>
        public ApplicationUserManager(
            IUserStore<User> store,
            IOptionsSnapshot<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            Microsoft.Extensions.Logging.ILogger<UserManager<User>> logger,
            IDistributedCacheService cacheService)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            this.DistributedCacheService = cacheService;
        }

        /// <summary>
        /// Finds the user by its object id.
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns>The user.</returns>
        public async Task<User?> FindUserByObjectIdAsync(string objectId)
        {
            var user = await this.DistributedCacheService.FindUserByObjectIdAsync(objectId);
            if (user != null)
            {
                return user;
            }

            user = await FindByNameAsync(objectId);

            if (user != null)
            {
                await this.DistributedCacheService.CacheUserAsync(user, TimeSpan.FromMinutes(30));
            }

            return user;
        }

        /// <summary>
        /// Clears the user's cache.
        /// </summary>
        /// <param name="objectId">The user's object id.</param>
        /// <returns>A <see cref="Task"/> representing the clearing of the user cache.</returns>
        public async Task ClearUserCacheAsync(string objectId)
        {
            await this.DistributedCacheService.ClearUserCacheAsync(objectId);
        }
    }
}
