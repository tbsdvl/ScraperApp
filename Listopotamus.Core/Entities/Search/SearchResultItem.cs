// <copyright file="SearchResultItem.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using Listopotamus.Core.Entities.Items;

namespace Listopotamus.Core.Entities.Search
{
    /// <summary>
    /// Represents a search result item.
    /// </summary>
    public class SearchResultItem : BaseExternalEntity<long?>
    {
        /// <summary>
        /// Gets or sets the search query id.
        /// </summary>
        [Required]
        public long? SearchQueryId { get; set; }

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        [Required]
        public long? ItemId { get; set; }

        /// <summary>
        /// Gets or sets the search query.
        /// </summary>
        public SearchQuery SearchQuery { get; set; }

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        public Item Item { get; set; }
    }
}
