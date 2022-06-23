using AutoMapper;
using Proje.Common.DTOs.DistributorToProduct;
using Proje.Common.Extensions;
using Proje.Web.UI.Areas.Admin.Models.DistributorToProductViewModels;

namespace Proje.Web.UI.Infrasructure.Mappers
{
    public class DistributorToProductMapperProfile : Profile
    {
        public DistributorToProductMapperProfile()
        {
            CreateMap<DistributorToProductViewModel, DistributorToProductRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<DistributorToProductViewModel, DistributorToProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateDistributorToProductViewModel, DistributorToProductRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateDistributorToProductViewModel, DistributorToProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateDistributorToProductViewModel, DistributorToProductRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateDistributorToProductViewModel, DistributorToProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
