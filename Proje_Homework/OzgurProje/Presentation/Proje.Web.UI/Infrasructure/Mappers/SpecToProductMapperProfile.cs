using AutoMapper;
using Proje.Common.DTOs.SpecToProduct;
using Proje.Common.Extensions;
using Proje.Web.UI.Areas.Admin.Models.SpecToProductViewModels;

namespace Proje.Web.UI.Infrasructure.Mappers
{
    public class SpecToProductMapperProfile : Profile
    {
        public SpecToProductMapperProfile()
        {
            CreateMap<SpecToProductViewModel, SpecToProductRequest>()
               .ReverseMap()
               .IgnoreAllNonExisting()
               .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<SpecToProductViewModel, SpecToProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateSpecToProductViewModel, SpecToProductRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateSpecToProductViewModel, SpecToProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateSpecToProductViewModel, SpecToProductRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateSpecToProductViewModel, SpecToProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
