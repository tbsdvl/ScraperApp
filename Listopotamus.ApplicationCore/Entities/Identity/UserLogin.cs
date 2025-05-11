// <copyright file="UserLogin.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;

namespace Listopotamus.ApplicationCore.Entities.Identity
{
    /// <summary>
    /// Represents a login associated with a user in the identity system.
    /// </summary>
    public class UserLogin : IdentityUserLogin<int>
    {
    }
}
