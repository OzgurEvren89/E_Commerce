using AutoMapper;
using Proje.Common.DTOs.SpecGroup;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class SpecGroupMapperProfile : Profile
    {
        public SpecGroupMapperProfile()
        {
            CreateMap<SpecGroup, SpecGroupRequest>()
               .ReverseMap()
               .IgnoreAllNonExisting()
               .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<SpecGroup, SpecGroupResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }

    }
}
