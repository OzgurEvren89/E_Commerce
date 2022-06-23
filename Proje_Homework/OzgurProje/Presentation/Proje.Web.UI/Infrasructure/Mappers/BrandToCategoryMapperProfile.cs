using AutoMapper;
using Proje.Common.DTOs.BrandToCategory;
using Proje.Common.Extensions;
using Proje.Web.UI.Areas.Admin.Models.BrandToCategoryViewModels;

namespace Proje.Web.UI.Infrasructure.Mappers
{
    public class BrandToCategoryToCategoryMapperProfile : Profile
    {
        public BrandToCategoryToCategoryMapperProfile()
        {
            CreateMap<BrandToCategoryViewModel, BrandToCategoryRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<BrandToCategoryViewModel, BrandToCategoryResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateBrandToCategoryViewModel, BrandToCategoryRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateBrandToCategoryViewModel, BrandToCategoryResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateBrandToCategoryViewModel, BrandToCategoryRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateBrandToCategoryViewModel, BrandToCategoryResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
