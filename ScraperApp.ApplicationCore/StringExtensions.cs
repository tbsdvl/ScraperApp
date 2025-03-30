// <copyright file="StringExtensions.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace ScraperApp.ApplicationCore.Extensions
{
    /// <summary>
    /// Represents string extension methods.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string price to a decimal.
        /// </summary>
        /// <param name="price">The string price to convert.</param>
        /// <returns>The decimal value of the price.</returns>
        public static decimal ToDecimalPrice(this string price)
        {
            if (string.IsNullOrWhiteSpace(price))
            {
                throw new ArgumentException("Price cannot be null or empty.", nameof(price));
            }

            if (decimal.TryParse(price.Replace("$", string.Empty), out decimal result))
            {
                return result;
            }

            throw new FormatException("Invalid price format.");
        }

        /// <summary>
        /// Parses a price range string and returns a tuple with the minimum and maximum prices.
        /// </summary>
        /// <param name="priceRange">The price range string to parse.</param>
        /// <returns>A tuple with the minimum and maximum prices.</returns>
        public static List<decimal> ToPriceRange(this string priceRange)
        {
            if (string.IsNullOrWhiteSpace(priceRange))
            {
                throw new ArgumentException("Price range cannot be null or empty.", nameof(priceRange));
            }

            var prices = priceRange.Split(" to ");
            if (prices.Length != 2)
            {
                throw new FormatException("Invalid price range format.");
            }

            if (decimal.TryParse(prices[0].Replace("$", string.Empty), out decimal minPrice) &&
                decimal.TryParse(prices[1].Replace("$", string.Empty), out decimal maxPrice))
            {
                return new ()
                {
                    minPrice,
                    maxPrice,
                };
            }

            throw new FormatException("Invalid price format.");
        }
    }
}
