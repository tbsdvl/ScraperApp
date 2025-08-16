// <copyright file="NodePathConstants.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace Listopotamus.ApplicationCore.Constants
{
    /// <summary>
    /// Represents the node constants.
    /// </summary>
    public class NodePathConstants
    {
        /// <summary>
        /// eBay-specific XPath selectors designed to survive markup variants.
        /// </summary>
        public static class Ebay
        {
            // Helper note:
            // Use contains(concat(' ', normalize-space(@class), ' '), ' className ')
            // to match class tokens regardless of order/spacing.

            /// <summary>
            /// List items under the results UL; matches either s-card or s-item templates.
            /// </summary>
            public const string ItemsList =
                "//ul[contains(concat(' ', normalize-space(@class), ' '), ' srp-results ')]" +
                "//li[" +
                    "contains(concat(' ', normalize-space(@class), ' '), ' s-card ') or " +
                    "contains(concat(' ', normalize-space(@class), ' '), ' s-item ')" +
                "]";

            /// <summary>
            /// Anchor to the item detail page (new su-link or legacy s-item__link).
            /// </summary>
            public const string ItemName =
                ".//a[" +
                    "contains(concat(' ', normalize-space(@class), ' '), ' su-link ') or " +
                    "contains(concat(' ', normalize-space(@class), ' '), ' s-item__link ')" +
                "]";

            /// <summary>
            /// Item price node(s). New s-card__price or legacy s-item__price.
            /// (Multiple nodes may exist for ranges like '$8.99 to $16.00'.)
            /// </summary>
            public const string ItemPrice =
                ".//span[" +
                    "contains(concat(' ', normalize-space(@class), ' '), ' s-card__price ') or " +
                    "contains(concat(' ', normalize-space(@class), ' '), ' s-item__price ')" +
                "]";

            /// <summary>
            /// Sold date/tag. Prefer the s-card caption; fall back to any 'Sold' tag.
            /// </summary>
            public const string SaleDate =
                ".//div[contains(concat(' ', normalize-space(@class), ' '), ' s-card__caption ')]" +
                "//span[contains(., 'Sold') or contains(., 'sold')]"
                + " | "
                + ".//span[contains(concat(' ', normalize-space(@class), ' '), ' s-item__title--tag ')][contains(., 'Sold')]";

            /// <summary>
            /// Item condition. Works for the new s-card subtitle or legacy secondary info.
            /// </summary>
            public const string Condition =
                ".//div[contains(concat(' ', normalize-space(@class), ' '), ' s-card__subtitle ')]" +
                "//span[contains(concat(' ', normalize-space(@class), ' '), ' su-styled-text ')]"
                + " | "
                + ".//span[contains(@class, 'SECONDARY_INFO') or contains(@class, 's-item__subtitle')]";

            /// <summary>
            /// Total bids (if present). Looks for text containing 'bids' within the item.
            /// </summary>
            public const string TotalBids =
                ".//span[contains(translate(., 'BIDS', 'bids'), 'bids')]";

            /// <summary>
            /// Buying format (e.g., 'Buy It Now', 'Auction', 'Best Offer').
            /// </summary>
            public const string BuyingFormat =
                ".//div[contains(concat(' ', normalize-space(@class), ' '), ' su-card-container__attributes__primary ')]" +
                "//div[contains(concat(' ', normalize-space(@class), ' '), ' s-card__attribute-row ')]" +
                "/span[contains(., 'Buy It Now') or contains(., 'Auction') or contains(., 'Best Offer')]"
                + " | "
                + ".//span[contains(concat(' ', normalize-space(@class), ' '), ' s-item__purchaseOptions ')]";

            /// <summary>
            /// 'Free delivery' / shipping. Supports new text and legacy logisticsCost.
            /// </summary>
            public const string HasFreeDelivery =
                ".//span[contains(translate(., 'FREE DELIVERY', 'free delivery'), 'free delivery')]"
                + " | "
                + ".//span[contains(concat(' ', normalize-space(@class), ' '), ' s-item__logisticsCost ')][contains(., 'Free')]";

            /// <summary>
            /// Total watchers (legacy). Kept for compatibility.
            /// </summary>
            public const string TotalWatchers =
                ".//span[contains(concat(' ', normalize-space(@class), ' '), ' s-item__watchers ')]";

            /// <summary>
            /// Has an offer/discount indicator (very broad by design).
            /// </summary>
            public const string HasOffer =
                ".//span[contains(., 'Offer') or contains(., 'offer') or contains(., 'Save up')]";

            /// <summary>
            /// Sponsored/promoted indicator.
            /// Matches legacy 'Sponsored' and the reversed 'derosnopS' trick.
            /// Also detects the s-item__sep badge container.
            /// </summary>
            public const string IsSponsored =
                ".//span[" +
                    "contains(concat(' ', normalize-space(@class), ' '), ' s-item__sep ') or " +
                    "contains(., 'Sponsored') or contains(., 'derosnopS')" +
                "]";

            /// <summary>
            /// Seller info line (e.g., 'ishampoo 98.3% positive (24.7K)').
            /// Targets % positive anywhere in the secondary attributes area.
            /// </summary>
            public const string SellerInfo =
                ".//div[contains(concat(' ', normalize-space(@class), ' '), ' su-card-container__attributes__secondary ')]" +
                "//span[contains(., '% positive')]"
                + " | "
                + ".//span[contains(concat(' ', normalize-space(@class), ' '), ' s-item__seller-info-text ')]";

            /// <summary>
            /// Quantity sold (number). We grab any 'sold' tag in attributes;
            /// parse numerics in application code to avoid false hits like dates.
            /// </summary>
            public const string QuantitySold =
                ".//div[contains(concat(' ', normalize-space(@class), ' '), ' s-card__attribute-row ')]" +
                "/span[contains(translate(., 'SOLD', 'sold'), 'sold')]"
                + " | "
                + ".//span[contains(concat(' ', normalize-space(@class), ' '), ' s-item__hotness ')]";

            /// <summary>
            /// Generic attribute row container (new or legacy).
            /// </summary>
            public const string AttributeRow =
                ".//div[contains(concat(' ', normalize-space(@class), ' '), ' s-card__attribute-row ')]"
                + " | "
                + ".//div[contains(concat(' ', normalize-space(@class), ' '), ' s-item__detail ')]";

            /// <summary>
            /// Secondary attributes container (new or legacy).
            /// </summary>
            public const string SecondaryAttributesContainer =
                ".//div[contains(concat(' ', normalize-space(@class), ' '), ' su-card-container__attributes__secondary ')]"
                + " | "
                + ".//div[contains(concat(' ', normalize-space(@class), ' '), ' s-item__details-section--secondary ')]";

            /// <summary>
            /// Seller info section (generalized for both templates).
            /// </summary>
            public const string SellerInfoSection =
                ".//div[contains(concat(' ', normalize-space(@class), ' '), ' su-card-container__attributes__secondary ')]"
                + "//span[contains(., '% positive')]"
                + " | "
                + ".//span[contains(concat(' ', normalize-space(@class), ' '), ' s-item__seller-info ')]";

            /// <summary>
            /// Item location text (e.g., 'Located in United States') or legacy location node.
            /// </summary>
            public const string Location =
                ".//div[contains(concat(' ', normalize-space(@class), ' '), ' s-card__attribute-row ')]" +
                "/span[contains(., 'Located in')]"
                + " | "
                + ".//span[contains(concat(' ', normalize-space(@class), ' '), ' s-item__location ')]";

            /// <summary>
            /// Positive feedback percentage (explicit match; same logic as SellerInfo).
            /// </summary>
            public const string PositiveFeedbackPercentage =
                ".//div[contains(concat(' ', normalize-space(@class), ' '), ' su-card-container__attributes__secondary ')]" +
                "//span[contains(., '% positive')]";
        }
    }
}
