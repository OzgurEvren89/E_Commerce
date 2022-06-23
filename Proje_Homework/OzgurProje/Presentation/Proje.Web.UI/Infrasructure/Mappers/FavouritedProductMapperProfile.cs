using AutoMapper;
using Proje.Common.DTOs.FavouritedProduct;
using Proje.Common.Extensions;
using Proje.Web.UI.Areas.Admin.Models.FavouritedProductViewModels;


namespace Proje.Web.UI.Infrasructure.Mappers
{
    public class FavouritedProductMapperProfile : Profile
    {
        public FavouritedProductMapperProfile()
        {
            CreateMap<FavouritedProductViewModel, FavouritedProductRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<FavouritedProductViewModel, FavouritedProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateFavouritedProductViewModel, FavouritedProductRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateFavouritedProductViewModel, FavouritedProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateFavouritedProductViewModel, FavouritedProductRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateFavouritedProductViewModel, FavouritedProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
