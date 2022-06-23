using AutoMapper;
using Proje.Common.DTOs.SpecName;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class SpecNameMapperProfile : Profile
    {
        public SpecNameMapperProfile()
        {
            CreateMap<SpecName, SpecNameRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<SpecName, SpecNameResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
