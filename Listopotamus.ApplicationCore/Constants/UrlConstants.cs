// <copyright file="UrlConstants.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace Listopotamus.ApplicationCore.Constants
{
    /// <summary>
    /// Represents the URL constants.
    /// </summary>
    public class UrlConstants
    {
        /// <summary>
        /// The eBay base url.
        /// </summary>
        public const string EBAY = "https://www.ebay.com/sch/";

        /// <summary>
        /// The eBay query param.
        /// </summary>
        public const string EBAYSEARCHQUERY = "?_nkw=";

        /// <summary>
        /// The eBay index.
        /// </summary>
        public const string EBAYINDEX = "/i.html";

        /// <summary>
        /// The eBay sold items query param.
        /// </summary>
        public const string EBAYSOLDITEMS = "&LH_Sold=1&LH_Complete=1";

        /// <summary>
        /// The eBay page number query param.
        /// </summary>
        public const string EBAYPAGENUM = "&_pgn=";

        /// <summary>
        /// The eBay zip code query param.
        /// </summary>
        public const string EBAYZIPCODE = "&_stpos=";

        /// <summary>
        /// The eBay distance query param.
        /// </summary>
        public const string EBAYDISTANCE = "&_sadis=";
    }
}
