// <copyright file="SearchQuery.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Listopotamus.ApplicationCore.Entities.Lookups;

namespace Listopotamus.ApplicationCore.Entities.Search
{
    /// <summary>
    /// Represents a search query.
    /// </summary>
    public class SearchQuery : BaseExternalEntity<long?>
    {
        /// <summary>
        /// Gets or sets the marketplace type id.
        /// </summary>
        [ForeignKey(nameof(MarketplaceType))]
        [Required]
        public int? MarketplaceTypeId { get; set; }

        /// <summary>
        /// Gets or sets the category type id.
        /// </summary>
        [Required]
        [ForeignKey(nameof(CategoryType))]
        public int? CategoryTypeId { get; set; }

        /// <summary>
        /// Gets or sets the search term.
        /// </summary>
        public string SearchTerm { get; set; }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        [Required]
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        public int? Distance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the distance is in miles or kilometers.
        /// </summary>
        public bool IsMiles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show sold items only.
        /// </summary>
        [Required]
        public bool ShowSoldOnly { get; set; }

        /// <summary>
        /// Gets or sets the max page number.
        /// </summary>
        public int? MaxPageNumber { get; set; }

        /// <summary>
        /// Gets or sets the list of search result items.
        /// </summary>
        public List<SearchResultItem> SearchResultItems { get; set; }

        /// <summary>
        /// Gets or sets the list of user searches.
        /// </summary>
        public List<UserSearch> UserSearches { get; set; }

        /// <summary>
        /// Gets or sets the marketplace type.
        /// </summary>
        public MarketplaceType MarketplaceType { get; set; }

        /// <summary>
        /// Gets or sets the category type.
        /// </summary>
        public CategoryType CategoryType { get; set; }
    }
}
