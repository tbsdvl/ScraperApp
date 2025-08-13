// <copyright file="ItemRepository.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Core.Entities.Items;
using Listopotamus.Infrastructure.Data.Repositories.Generic;

namespace Listopotamus.Infrastructure.Data.Repositories.Scraper
{
    /// <summary>
    /// Represents the item repository.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ItemRepository"/> class.
    /// </remarks>
    /// <param name="context">The application database context.</param>
    public class ItemRepository(ApplicationDbContext context) : GenericRepository<Item, long?>(context), IItemRepository
    {
    }
}
