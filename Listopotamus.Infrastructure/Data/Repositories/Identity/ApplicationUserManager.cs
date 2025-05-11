// <copyright file="ApplicationUserManager.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.Core.Entities.Identity;
using Listopotamus.Infrastructure.Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Listopotamus.Infrastructure.Data.Repositories.Identity
{
    /// <summary>
    /// Represents the application user manager.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ApplicationUserManager"/> class.
    /// </remarks>
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
    public class ApplicationUserManager(
        IUserStore<User> store,
        IOptionsSnapshot<IdentityOptions> optionsAccessor,
        IPasswordHasher<User> passwordHasher,
        IEnumerable<IUserValidator<User>> userValidators,
        IEnumerable<IPasswordValidator<User>> passwordValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        IServiceProvider services,
        Microsoft.Extensions.Logging.ILogger<UserManager<User>> logger,
        IDistributedCacheService cacheService) : UserManager<User>(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger), IApplicationUserManager
    {
        /// <summary>
        /// Gets the distributed cache service.
        /// </summary>
        private IDistributedCacheService DistributedCacheService { get; } = cacheService;

        /// <inheritdoc />
        public async Task<IdentityResult> CreateAsync(User user, string password, IEnumerable<string> roles)
        {
            var result = await this.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                return result;
            }

            result = await this.AddToRolesAsync(user, roles);
            if (result.Succeeded)
            {
                await this.DistributedCacheService.CacheUserAsync(user, TimeSpan.FromMinutes(30));
            }

            return result;
        }

        /// <inheritdoc />
        public async Task<IdentityResult> UpdateAsync(User user, IEnumerable<string> roles)
        {
            var result = await this.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return result;
            }

            var currentRoles = await this.GetRolesAsync(user);

            var rolesToRemove = currentRoles.Except(roles);
            if (rolesToRemove.Any())
            {
                result = await this.RemoveFromRolesAsync(user, rolesToRemove);
                if (!result.Succeeded)
                {
                    return result;
                }
            }

            var rolesToAdd = roles.Except(currentRoles);
            if (rolesToAdd.Any())
            {
                result = await this.AddToRolesAsync(user, rolesToAdd);
                if (!result.Succeeded)
                {
                    return result;
                }
            }

            await this.DistributedCacheService.CacheUserAsync(user, TimeSpan.FromMinutes(30));

            return result;
        }

        /// <inheritdoc />
        public async Task<User?> FindAsync(string name)
        {
            return await this.FindByNameAsync(name);
        }

        /// <inheritdoc />
        public async Task<User?> FindAsync(int id)
        {
            return await this.FindByIdAsync(id.ToString());
        }

        /// <inheritdoc />
        public async Task<User?> FindAsync(Guid externalId)
        {
            var user = await this.DistributedCacheService.FindUserByObjectIdAsync(externalId.ToString());
            if (user is not null)
            {
                return user;
            }

            user = this.Users.FirstOrDefault(u => u.ExternalId.Equals(externalId));
            if (user is not null)
            {
                await this.DistributedCacheService.CacheUserAsync(user, TimeSpan.FromMinutes(30));
            }

            return user;
        }

        /// <inheritdoc />
        public async Task<User?> FindUserByObjectIdAsync(string objectId)
        {
            var user = await this.DistributedCacheService.FindUserByObjectIdAsync(objectId);
            if (user is not null)
            {
                return user;
            }

            user = await this.FindByNameAsync(objectId);

            if (user is not null)
            {
                await this.DistributedCacheService.CacheUserAsync(user, TimeSpan.FromMinutes(30));
            }

            return user;
        }

        /// <inheritdoc />
        public async Task ClearUserCacheAsync(string objectId)
        {
            await this.DistributedCacheService.ClearUserCacheAsync(objectId);
        }
    }
}
