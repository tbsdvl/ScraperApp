// <copyright file="SearchQueryRepository.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Entities.Search;
using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Infrastructure.Data.Repositories.Generic;

namespace Listopotamus.Infrastructure.Data.Repositories.Scraper
{
    /// <summary>
    /// Represents the search query repository.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="SearchQueryRepository"/> class.
    /// </remarks>
    /// <param name="context">The application database context.</param>
    public class SearchQueryRepository(ApplicationDbContext context) : GenericRepository<SearchQuery, long?>(context), ISearchQueryRepository
    {
    }
}
