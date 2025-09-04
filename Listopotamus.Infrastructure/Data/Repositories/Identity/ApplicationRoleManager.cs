// <copyright file="ApplicationRoleManager.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.Infrastructure.Security.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Listopotamus.Infrastructure.Data.Repositories.Identity
{
    /// <summary>
    /// Represents the application role manager.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ApplicationRoleManager"/> class.
    /// </remarks>
    /// <param name="store">The role store.</param>
    /// <param name="roleValidators">The list of role validators.</param>
    /// <param name="keyNormalizer">The key normalizer.</param>
    /// <param name="errors">The list of errors.</param>
    /// <param name="logger">The logger.</param>
    public class ApplicationRoleManager(
        IRoleStore<Role> store,
        IEnumerable<IRoleValidator<Role>> roleValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        ILogger<RoleManager<Role>> logger) : RoleManager<Role>(store, roleValidators, keyNormalizer, errors, logger)
    {
    }
}
