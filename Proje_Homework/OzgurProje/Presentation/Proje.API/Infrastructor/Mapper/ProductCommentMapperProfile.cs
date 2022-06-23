using AutoMapper;
using Proje.Common.DTOs.ProductComment;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class ProductCommentMapperProfile : Profile
    {
        public ProductCommentMapperProfile()
        {
            CreateMap<ProductComment, ProductCommentRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ProductComment, ProductCommentResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
