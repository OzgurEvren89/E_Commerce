using AutoMapper;
using Proje.Common.DTOs.PhoneNumber;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class PhoneNumberMapperProfile : Profile
    {
        public PhoneNumberMapperProfile()
        {
            CreateMap<PhoneNumber, PhoneNumberRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PhoneNumber, PhoneNumberResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
