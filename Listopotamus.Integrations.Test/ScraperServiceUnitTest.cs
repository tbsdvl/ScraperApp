using Listopotamus.ApplicationCore.DTOs;
using Listopotamus.ApplicationCore.Enums;
using Listopotamus.ApplicationCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Text;

namespace Listopotamus.Integrations.Test
{
    [TestClass]
    public sealed class ScraperServiceUnitTest : BaseUnitTest
    {           
        private IBaseScraperService ScraperService { get; set; }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            this.ScraperService = this.ServiceProvider.GetRequiredService<IBaseScraperService>();
        }

        private static SearchCriteriaModel GetScraperRequest()
        {
            return new SearchCriteriaModel()
            {
                Url = "https://ebay.com",
                Query = new EbaySearchQueryDto()
                {
                    SearchTerm = "test",
                    SoldItemsOnly = false,
                    MaxPageNumber = 2,
                    LocationTypeId = (int)LocationTypeEnum.US,
                },
            };
        }
        private static string EscapeCsv(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";
            if (value.Contains(",") || value.Contains("\""))
                return $"\"{value.Replace("\"", "\"\"")}\"";
            return value;
        }

        [TestMethod]
        public async Task GetItemsAsync_Succeeds()
        {
            // Arrange
            var request = GetScraperRequest();

            // Act
            var result = await this.ScraperService.GetItemsAsync(request);

            // Assert
            Assert.IsTrue(result.IsSuccess, "The response failed to return a list of items.");
            Assert.IsTrue(result.Content.Count > 0, "List of items is empty.");
        }

        [TestMethod]
        public async Task GetItemsAsync_No_Items_Found_Fails()
        {
            // Arrange
            var request = GetScraperRequest();

            // searching for generic products like "shoes" returns a different search results page structure.
            request.Query.SearchTerm = "shoes";

            // Act
            var result = await this.ScraperService.GetItemsAsync(request);

            // Assert
            Assert.IsFalse(result.IsSuccess, "The response successfully returned a list of items.");
            Assert.AreEqual(0, result.Content.Count, "List of items is not empty.");
        }

        [TestMethod]
        public async Task GetItemsAsync_Sold_Items_Succeeds()
        {
            // Arrange
            var request = GetScraperRequest();
            request.Query.SoldItemsOnly = true;

            // Act
            var result = await this.ScraperService.GetItemsAsync(request);

            // Assert
            Assert.IsTrue(result.IsSuccess, "The response failed to return a list of items.");
            Assert.IsTrue(result.Content.Count > 0, "List of items is empty.");
            Assert.IsTrue(result.Content.First().SaleDate > DateTime.MinValue,
                "The first item in the list should have a sale date when SoldItemsOnly is true.");
        }

        [TestMethod]
        public async Task GetItemsAsync_Sold_Items_Report_Succeeds()
        {
            // Arrange
            var request = GetScraperRequest();
            request.Query.SearchTerm = "gun parts"; // configure search term
            request.Query.CategoryTypeCode = (int)CategoryTypeEnum.GunParts; // configure category
            request.Query.MaxPageNumber = 200;
            request.Query.LocationTypeId = null;
            request.Query.SoldItemsOnly = true;

            // Act
            var result = await this.ScraperService.GetItemsAsync(request);

            // Assert
            Assert.IsTrue(result.IsSuccess, "The response failed to return a list of items.");
            Assert.IsTrue(result.Content.Count > 0, "List of items is empty.");
            Assert.IsTrue(result.Content.First().SaleDate > DateTime.MinValue,
                "The first item in the list should have a sale date when SoldItemsOnly is true.");

            var csvFilePath = $"{request.Query.SearchTerm.Replace(" ", "_")}_items.csv";
            using var writer = new StreamWriter(csvFilePath, false, Encoding.UTF8);
            
            // Write CSV header
            writer.WriteLine(
                "CategoryTypeId,MarketplaceTypeId,LocationTypeId,ElementId,Name,HasUpperCaseName,MinPrice,MaxPrice,SaleDate,TotalWatchers,Condition,TotalBids,BuyingFormat,HasFreeDelivery,QuantitySold,HasOffer,IsSponsored,SellerName,TotalSellerReviews,SellerRating,Location"
            );

            // Write each item as a CSV row
            foreach (var item in result.Content)
            {
                writer.WriteLine(string.Join(",",
                    item.CategoryTypeId?.ToString() ?? "",
                    item.MarketplaceTypeId?.ToString() ?? "",
                    item.LocationTypeId?.ToString() ?? "",
                    EscapeCsv(item.ElementId),
                    EscapeCsv(item.Name),
                    item.HasUpperCaseName.ToString(CultureInfo.InvariantCulture),
                    item.MinPrice.ToString(CultureInfo.InvariantCulture),
                    item.MaxPrice?.ToString(CultureInfo.InvariantCulture) ?? "",
                    item.SaleDate?.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) ?? "",
                    item.TotalWatchers?.ToString() ?? "",
                    EscapeCsv(item.Condition),
                    item.TotalBids?.ToString() ?? "",
                    item.BuyingFormat?.ToString() ?? "",
                    item.HasFreeDelivery.ToString(CultureInfo.InvariantCulture),
                    item.QuantitySold?.ToString() ?? "",
                    item.HasOffer.ToString(CultureInfo.InvariantCulture),
                    item.IsSponsored.ToString(CultureInfo.InvariantCulture),
                    EscapeCsv(item.SellerName),
                    item.TotalSellerReviews?.ToString() ?? "",
                    item.SellerRating?.ToString(CultureInfo.InvariantCulture) ?? "",
                    EscapeCsv(item.Location)
                ));
            }
        }
    }
}
