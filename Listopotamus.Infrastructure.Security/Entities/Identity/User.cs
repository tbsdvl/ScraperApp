// <copyright file="User.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Listopotamus.Infrastructure.Security.Entities.Identity
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    public class User : IdentityUser<Guid>
    {
    }
}
