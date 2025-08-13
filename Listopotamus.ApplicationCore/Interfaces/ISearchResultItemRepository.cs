// <copyright file="ISearchResultItem.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.Core.Entities.Search;

namespace Listopotamus.ApplicationCore.Interfaces
{
    /// <summary>
    /// Represents the interface for the search result item repository.
    /// </summary>
    public interface ISearchResultItemRepository : IGenericRepository<SearchResultItem, long?>
    {
    }
}
