// <copyright file="ScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using AutoMapper;
using HtmlAgilityPack;
using ScraperApp.ApplicationCore.Enums;
using ScraperApp.ApplicationCore.Models;

namespace ScraperApp.ApplicationCore.Services
{
    /// <summary>
    /// Provides services related to retrieving and processing HTML data.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ScraperService"/> class.
    /// </remarks>
    /// <param name="mapper">The mapper.</param>
    public class ScraperService(IMapper mapper)
    {
        /// <summary>
        /// Gets or sets the mapper.
        /// </summary>
        private IMapper Mapper { get; set; } = mapper;

        /// <summary>
        /// Gets a page's HTML.
        /// </summary>
        /// <param name="request">The scraper request.</param>
        /// <returns>The page's HTML.</returns>
        public async Task<Result> GetPageHtml(ScraperRequest request)
        {
            switch (request.Options.QueryOptionsType)
            {
                case (int)QueryOptionsTypeEnum.Ebay:
                    request.Options = this.Mapper.Map<EbayQueryOptions>(request.Options);
                    break;
                default:
                    return new Result
                    {
                        Succeeded = false,
                    };
            }

            var webUtility = new HtmlWeb();
            var htmlDoc = await webUtility.LoadFromWebAsync(request.Url);

            return new Result
            {
                Succeeded = true,
                Data = htmlDoc,
            };
        }
    }
}
