// <copyright file="ScraperService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using HtmlAgilityPack;

namespace ScraperApp.ApplicationCore.Services
{
    /// <summary>
    /// Provides services related to retrieving and processing HTML data.
    /// </summary>
    public class ScraperService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScraperService"/> class.
        /// </summary>
        public ScraperService()
        {
        }

        /// <summary>
        /// Gets a page's HTML.
        /// </summary>
        /// <returns>The page's HTML.</returns>
        public async Task GetPageHtml()
        {
            var html = @"https://html-agility-pack.net/";

            var web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");
        }
    }
}
