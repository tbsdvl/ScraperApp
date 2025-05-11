// <copyright file="AutoMapperProfile.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using AutoMapper;
using Listopotamus.ApplicationCore.DTOs;
using Listopotamus.Core.Entities;
using Listopotamus.Core.Entities.Items;

namespace Listopotamus.ApplicationCore
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
            this.CreateMap<EbaySearchQueryDto, SearchQueryDto>()
                .ReverseMap();

            this.CreateMap<ItemDto, Item>()
                .ReverseMap();

            this.CreateMap<LookupDto, BaseLookupEntity>()
                .ReverseMap();
        }
    }
}
