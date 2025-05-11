// <copyright file="UserToken.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;

namespace Listopotamus.ApplicationCore.Entities.Identity
{
    /// <summary>
    /// Represents a token associated with a user in the identity system.
    /// </summary>
    public class UserToken : IdentityUserToken<int>
    {
    }
}
