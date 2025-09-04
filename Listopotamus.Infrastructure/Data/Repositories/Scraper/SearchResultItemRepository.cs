// <copyright file="SearchResultItemRepository.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Entities.Search;
using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Infrastructure.Data.Repositories.Generic;

namespace Listopotamus.Infrastructure.Data.Repositories.Scraper
{
    /// <summary>
    /// Represents the search result item repository.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="SearchResultItemRepository"/> class.
    /// </remarks>
    /// <param name="context">The application database context.</param>
    public class SearchResultItemRepository(ApplicationDbContext context) : GenericRepository<SearchResultItem, long?>(context), ISearchResultItemRepository
    {
    }
}