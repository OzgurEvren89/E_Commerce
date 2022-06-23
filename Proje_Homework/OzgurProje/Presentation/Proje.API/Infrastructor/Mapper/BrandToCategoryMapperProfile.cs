using AutoMapper;
using Proje.Common.DTOs.BrandToCategory;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class BrandToCategoryMapperProfile : Profile
    {
        public BrandToCategoryMapperProfile()
        {
            CreateMap<BrandToCategory, BrandToCategoryRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<BrandToCategory, BrandToCategoryResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
