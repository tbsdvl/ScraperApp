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
                cfg.AddProfile<AutoMapperProfile>(); // Register the AutoMapper profile
            });

            this.Mapper = mappingConfig.CreateMapper();

            this.ScraperService = new ScraperService(this.Mapper);
        }

        private static ScraperRequest GetScraperRequest()
        {
            return new ScraperRequest()
            {
                Url = "https://ebay.com",
                Options = new QueryOptions()
                {
                    QueryOptionsType = (int)QueryOptionsTypeEnum.Ebay,
                },
            };
        }

        [TestMethod]
        public async Task GetPage_Succeeds()
        {
            // Arrange
            var request = GetScraperRequest();

            // Act
            var result = await this.ScraperService.GetPageHtml(request);

            // Assert
            Assert.IsTrue(result.Succeeded);
            Assert.IsTrue(result.Data != null);
        }

        [TestMethod]
        public async Task GetPage_No_Query_Options_Type_Fails()
        {
            // Arrange
            var request = GetScraperRequest();
            request.Options.QueryOptionsType = 0;

            // Act
            var result = await this.ScraperService.GetPageHtml(request);

            // Assert
            Assert.IsTrue(result.Succeeded);
            Assert.IsTrue(result.Data != null);
        }
    }
}
