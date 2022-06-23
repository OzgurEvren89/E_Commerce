using AutoMapper;
using Proje.Common.DTOs.FavouritedProduct;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class FavouritedProductMapperProfile : Profile
    {
        public FavouritedProductMapperProfile()
        {
            CreateMap<FavouritedProduct, FavouritedProductRequest>()
               .ReverseMap()
               .IgnoreAllNonExisting()
               .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<FavouritedProduct, FavouritedProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
