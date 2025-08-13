// <copyright file="IUserSearchRepository.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.Core.Entities.Search;

namespace Listopotamus.ApplicationCore.Interfaces
{
    /// <summary>
    /// Represents the interface for the user search repository.
    /// </summary>
    public interface IUserSearchRepository : IGenericRepository<UserSearch, long?>
    {
    }
}
