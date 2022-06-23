using AutoMapper;
using Proje.Common.DTOs.PhoneNumberType;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class PhoneNumberTypeMapperProfile : Profile
    {
        public PhoneNumberTypeMapperProfile()
        {
            CreateMap<PhoneNumberType, PhoneNumberTypeRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PhoneNumberType, PhoneNumberTypeResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
