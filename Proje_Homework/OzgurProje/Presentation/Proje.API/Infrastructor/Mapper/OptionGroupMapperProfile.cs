using AutoMapper;
using Proje.Common.DTOs.OptionGroup;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class OptionGroupMapperProfile : Profile
    {
        public OptionGroupMapperProfile()
        {
            CreateMap<OptionGroup, OptionGroupRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<OptionGroup, OptionGroupResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
