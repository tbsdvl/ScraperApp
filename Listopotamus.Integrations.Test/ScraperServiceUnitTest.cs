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

        private static SearchCriteriaModel GetSearchCriteriaModel()
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
            var request = GetSearchCriteriaModel();

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
            var searchCriteria = GetSearchCriteriaModel();

            // searching for generic products like "shoes" returns a different search results page structure.
            searchCriteria.Query.SearchTerm = "shoes";

            // Act
            var result = await this.ScraperService.GetItemsAsync(searchCriteria);

            // Assert
            Assert.IsFalse(result.IsSuccess, "The response successfully returned a list of items.");
        }

        [TestMethod]
        public async Task GetItemsAsync_Sold_Items_Succeeds()
        {
            // Arrange
            var searchCriteria = GetSearchCriteriaModel();
            searchCriteria.Query.SoldItemsOnly = true;

            // Act
            var result = await this.ScraperService.GetItemsAsync(searchCriteria);

            // Assert
            Assert.IsTrue(result.IsSuccess, "The response failed to return a list of items.");
            Assert.IsTrue(result.Content.Count > 0, "List of items is empty.");
            Assert.IsTrue(result.Content.First().SaleDate > DateTime.MinValue,
                "The first item in the list should have a sale date when SoldItemsOnly is true.");
        }
    }
}
