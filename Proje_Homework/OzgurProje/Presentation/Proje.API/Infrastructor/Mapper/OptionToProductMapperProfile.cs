using AutoMapper;
using Proje.Common.DTOs.OptionToProduct;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class OptionToProductMapperProfile : Profile
    {
        public OptionToProductMapperProfile()
        {
            CreateMap<OptionToProduct, OptionToProductRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<OptionToProduct, OptionToProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
