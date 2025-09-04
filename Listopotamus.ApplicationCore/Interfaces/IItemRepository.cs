// <copyright file="IItemRepository.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Entities.Items;

namespace Listopotamus.ApplicationCore.Interfaces
{
    /// <summary>
    /// Represents the interface for the item repository.
    /// </summary>
    public interface IItemRepository : IGenericRepository<Item, long?>
    {
    }
}
