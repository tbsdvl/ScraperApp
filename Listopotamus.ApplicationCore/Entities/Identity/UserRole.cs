// <copyright file="UserRole.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;

namespace Listopotamus.ApplicationCore.Entities.Identity
{
    /// <summary>
    /// Represents a user role in the identity system.
    /// </summary>
    public class UserRole : IdentityUserRole<int>
    {
    }
}
