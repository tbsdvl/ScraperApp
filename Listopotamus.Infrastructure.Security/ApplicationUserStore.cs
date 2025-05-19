// <copyright file="ApplicationUserManager.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.Infrastructure.Security.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Listopotamus.Infrastructure.Security
{
    /// <summary>
    /// The application user store repository.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ApplicationUserStore{TContext}"/> class.
    /// </remarks>
    /// <param name="context">The context.</param>
    /// <param name="describer">The error describer.</param>
    public class ApplicationUserStore<TContext>(TContext context, IdentityErrorDescriber describer = null) : UserStore<User, Role, TContext, int>(context, describer), IApplicationUserStore
        where TContext : DbContext
    {
        /// <summary>
        /// Gets the list of roles in the system.
        /// </summary>
        private DbSet<Role> AspNetRoles => Context.Set<Role>();

        /// <summary>
        /// Gets the list of user mapped to roles.
        /// </summary>
        private DbSet<IdentityUserRole<int>> AspNetUserRoles => Context.Set<IdentityUserRole<int>>();
    }
}
