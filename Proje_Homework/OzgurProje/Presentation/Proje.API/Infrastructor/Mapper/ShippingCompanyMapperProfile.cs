using AutoMapper;
using Proje.Common.DTOs.ShippingCompany;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class ShippingCompanyMapperProfile : Profile
    {
        public ShippingCompanyMapperProfile()
        {
            CreateMap<ShippingCompany, ShippingCompanyRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ShippingCompany, ShippingCompanyResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
