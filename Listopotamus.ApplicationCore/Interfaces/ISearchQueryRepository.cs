// <copyright file="ISearchQueryRepository.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Entities.Search;

namespace Listopotamus.ApplicationCore.Interfaces
{
    /// <summary>
    /// Represents the interface for the search query repository.
    /// </summary>
    public interface ISearchQueryRepository : IGenericRepository<SearchQuery, long?>
    {
    }
}
