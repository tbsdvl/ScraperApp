// <copyright file="IUserContextService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace Listopotamus.ApplicationCore.Interfaces
{
    /// <summary>
    /// Represents the user context service interface.
    /// </summary>
    public interface IUserContextService
    {
        /// <summary>
        /// Gets the user id.
        /// </summary>
        /// <returns>The user id.</returns>
        string GetUserId();
    }
}
