using AutoMapper;
using Proje.Common.DTOs.DemandReason;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class DemandReasonMapperProfile : Profile
    {
        public DemandReasonMapperProfile()
        {
            CreateMap<DemandReason, DemandReasonRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<DemandReason, DemandReasonResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
