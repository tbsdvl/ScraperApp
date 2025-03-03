using AutoMapper;
using ScraperApp.ApplicationCore;
using ScraperApp.ApplicationCore.Enums;
using ScraperApp.ApplicationCore.Models;
using ScraperApp.ApplicationCore.Services;

namespace ScraperApp.Integrations.Test
{
    [TestClass]
    public sealed class ScraperServiceUnitTest
    {
        private IMapper Mapper { get; set; }
        private ScraperService ScraperService { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            this.Mapper = mappingConfig.CreateMapper();

            this.ScraperService = new ScraperService(this.Mapper);
        }

        private static ScraperRequest GetScraperRequest()
        {
            return new ScraperRequest()
            {
                Url = "https://ebay.com",
                Options = new EbayQueryOptions()
                {
                    SearchTerm = "test",
                },
            };
        }

        [TestMethod]
        public async Task GetItems_Succeeds()
        {
            // Arrange
            var request = GetScraperRequest();

            // Act
            var result = await this.ScraperService.GetItems(request);

            // Assert
            Assert.IsTrue(result.Items.Count > 0, "List of items is empty.");
        }
    }
}
