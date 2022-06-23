using AutoMapper;
using Proje.Common.DTOs.DistributorToProduct;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class DistributorToProductMapperProfile : Profile
    {
        public DistributorToProductMapperProfile()
        {
            CreateMap<DistributorToProduct, DistributorToProductRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<DistributorToProduct, DistributorToProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
