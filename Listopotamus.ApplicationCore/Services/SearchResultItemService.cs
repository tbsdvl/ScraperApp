// <copyright file="SearchResultItemService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Entities.Items;
using Listopotamus.ApplicationCore.Entities.Search;
using Listopotamus.ApplicationCore.Interfaces;

namespace Listopotamus.ApplicationCore.Services
{
    /// <summary>
    /// Represents the search result item service.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="SearchResultItemService"/> class.
    /// </remarks>
    /// <param name="searchResultItemRepository">The search result item repository.</param>
    public class SearchResultItemService(ISearchResultItemRepository searchResultItemRepository) : ISearchResultItemService
    {
        /// <summary>
        /// Gets the search result item repository.
        /// </summary>
        private ISearchResultItemRepository SearchResultItemRepository { get; } = searchResultItemRepository;

        /// <summary>
        /// Creates a list of search result items.
        /// </summary>
        /// <param name="searchQueryId">The search query id.</param>
        /// <param name="savedItems">The list of saved items.</param>
        /// <returns>The list of search result items.</returns>
        public async Task CreateAsync(long searchQueryId, List<Item> savedItems)
        {
            var searchResultItems = new List<SearchResultItem>();
            foreach (var item in savedItems)
            {
                var searchResultItem = new SearchResultItem
                {
                    SearchQueryId = searchQueryId,
                    ItemId = item.Id,
                    ExternalId = Guid.NewGuid(),
                };
                searchResultItems.Add(searchResultItem);
            }

            await this.SearchResultItemRepository.InsertAsync(searchResultItems);
        }
    }
}
