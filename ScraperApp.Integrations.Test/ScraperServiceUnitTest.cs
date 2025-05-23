﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ScraperApp.ApplicationCore;
using ScraperApp.ApplicationCore.Models;
using ScraperApp.ApplicationCore.Services;

namespace ScraperApp.Integrations.Test
{
    [TestClass]
    public sealed class ScraperServiceUnitTest
    {           
        private ScraperService ScraperService { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(mappingConfig.CreateMapper());
            serviceCollection.TryAddTransient<EbayScraperService>();
            serviceCollection.TryAddTransient<ScraperService>();
            
            var serviceProvider = serviceCollection.BuildServiceProvider();

            this.ScraperService = serviceProvider.GetRequiredService<ScraperService>();
        }

        private static ScraperRequest GetScraperRequest()
        {
            return new ScraperRequest()
            {
                Url = "https://ebay.com",
                Options = new EbayQueryOptions()
                {
                    SearchTerm = "test",
                    SoldItemsOnly = false,
                    MaxPageNumber = 2,
                },
            };
        }

        [TestMethod]
        public async Task GetItemsAsync_Succeeds()
        {
            // Arrange
            var request = GetScraperRequest();

            // Act
            var result = await this.ScraperService.GetItemsAsync(request);

            // Assert
            Assert.IsTrue(result.Items.Count > 0, "List of items is empty.");
            Assert.IsTrue(result.Succeeded, "The response failed to return a list of items.");
        }

        [TestMethod]
        public async Task GetItemsAsync_No_Items_Found_Fails()
        {
            // Arrange
            var request = GetScraperRequest();

            // searching for generic products like "shoes" returns a different search results page structure.
            request.Options.SearchTerm = "shoes";

            // Act
            var result = await this.ScraperService.GetItemsAsync(request);

            // Assert
            Assert.IsTrue(result.Items.Count == 0, "List of items is not empty.");
            Assert.IsFalse(result.Succeeded, "The response successfully returned a list of items.");
        }

        [TestMethod]
        public async Task GetItemsAsync_Sold_Items_Succeeds()
        {
            // Arrange
            var request = GetScraperRequest();
            request.Options.SoldItemsOnly = true;

            // Act
            var result = await this.ScraperService.GetItemsAsync(request);

            // Assert
            Assert.IsTrue(result.Items.Count > 0, "List of items is empty.");
            Assert.IsTrue(result.Succeeded, "The response failed to return a list of items.");
            Assert.IsTrue(result.Items.First().SaleDate > DateTime.MinValue,
                "The first item in the list should have a sale date when SoldItemsOnly is true.");
        }
    }
}
