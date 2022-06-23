using AutoMapper;
using Proje.Common.DTOs.ProductDetail;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class ProductDetailMapperProfile : Profile
    {
        public ProductDetailMapperProfile()
        {
            CreateMap<ProductDetail, ProductDetailRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ProductDetail, ProductDetailResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
