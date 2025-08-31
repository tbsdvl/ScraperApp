// <copyright file="IItemService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.DTOs;

namespace Listopotamus.ApplicationCore.Interfaces
{
    /// <summary>
    /// Represents the item service interface.
    /// </summary>
    public interface IItemService
    {
        /// <summary>
        /// Creates a list of items.
        /// </summary>
        /// <param name="searchQueryId">The seach query id.</param>
        /// <param name="newItems">The list of new items.</param>
        /// <returns>A <see cref="Task"/> representing the insertion of the search result items.</returns>
        Task CreateAsync(long? searchQueryId, List<ItemDto> newItems);
    }
}
