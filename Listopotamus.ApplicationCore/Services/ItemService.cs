// <copyright file="ItemService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.Transactions;
using AutoMapper;
using Listopotamus.ApplicationCore.DTOs;
using Listopotamus.ApplicationCore.Entities.Items;
using Listopotamus.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Listopotamus.ApplicationCore.Services
{
    /// <summary>
    /// Represents the item service.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ItemService"/> class.
    /// </remarks>
    /// <param name="mapper">The mapper.</param>
    /// <param name="itemRepository">The item repository.</param>
    /// <param name="httpContextAccessor">The http context accessor.</param>
    public class ItemService(IMapper mapper, IItemRepository itemRepository, ISearchResultItemService searchResultItemService, IHttpContextAccessor httpContextAccessor) : IItemService
    {
        /// <summary>
        /// Gets the mapper.
        /// </summary>
        private IMapper Mapper { get; } = mapper;

        /// <summary>
        /// Gets the item repository.
        /// </summary>
        private IItemRepository ItemRepository { get; } = itemRepository;

        /// <summary>
        /// Gets the search result item service.
        /// </summary>
        private ISearchResultItemService SearchResultItemService { get; } = searchResultItemService;

        /// <summary>
        /// Creates a list of items.
        /// </summary>
        /// <param name="searchQueryId">The seach query id.</param>
        /// <param name="newItems">The list of new items.</param>
        /// <returns>A <see cref="Task"/> representing the insertion of the search result items.</returns>
        public async Task CreateAsync(long searchQueryId, List<ItemDto> newItems)
        {
            if (newItems.Count == 0)
            {
                return;
            }

            var itemEntities = this.Mapper.Map<List<Item>>(newItems);

            var options = new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted };
            using var scope = new TransactionScope(TransactionScopeOption.Required, options, TransactionScopeAsyncFlowOption.Enabled);

            var savedItems = await this.ItemRepository.InsertAsync(itemEntities);
            await this.SearchResultItemService.CreateAsync(searchQueryId, savedItems);

            scope.Complete();
        }
    }
}
