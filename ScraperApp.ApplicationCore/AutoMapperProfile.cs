// <copyright file="AutoMapperProfile.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using AutoMapper;
using ScraperApp.ApplicationCore.Entities;
using ScraperApp.ApplicationCore.Models;

namespace ScraperApp.ApplicationCore
{
    /// <summary>
    /// Represents the application core auto mapper profile.
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperProfile"/> class.
        /// </summary>
        public AutoMapperProfile()
        {
            this.CreateMap<EbayQueryOptions, QueryOptions>()
                .ReverseMap();

            this.CreateMap<ItemModel, Item>()
                .ReverseMap();

            this.CreateMap<LookupModel, BaseLookupEntity>()
                .ReverseMap();
        }
    }
}
