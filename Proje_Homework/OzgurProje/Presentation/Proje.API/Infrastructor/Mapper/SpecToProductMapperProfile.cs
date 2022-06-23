using AutoMapper;
using Proje.Common.DTOs.SpecToProduct;
using Proje.Common.Extensions;
using Proje.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.API.Infrastructor.Mapper
{
    public class SpecToProductMapperProfile : Profile
    {
        public SpecToProductMapperProfile()
        {
            CreateMap<SpecToProduct, SpecToProductRequest>()
               .ReverseMap()
               .IgnoreAllNonExisting()
               .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<SpecToProduct, SpecToProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
