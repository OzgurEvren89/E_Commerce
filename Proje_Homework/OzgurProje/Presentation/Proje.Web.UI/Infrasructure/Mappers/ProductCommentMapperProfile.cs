using AutoMapper;
using Proje.Common.DTOs.ProductComment;
using Proje.Common.Extensions;
using Proje.Web.UI.Areas.Admin.Models.ProductCommentViewModels;


namespace Proje.Web.UI.Infrasructure.Mappers
{
    public class ProductCommentMapperProfile : Profile
    {
        public ProductCommentMapperProfile()
        {
            CreateMap<ProductCommentViewModel, ProductCommentRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ProductCommentViewModel, ProductCommentResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateProductCommentViewModel, ProductCommentRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateProductCommentViewModel, ProductCommentResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateProductCommentViewModel, ProductCommentRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateProductCommentViewModel, ProductCommentResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
