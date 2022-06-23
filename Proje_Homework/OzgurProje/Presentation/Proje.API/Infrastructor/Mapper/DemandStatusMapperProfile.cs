using AutoMapper;
using Proje.Common.DTOs.DemandStatus;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class DemandStatusMapperProfile : Profile
    {
        public DemandStatusMapperProfile()
        {
            CreateMap<DemandStatus, DemandStatusRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<DemandStatus, DemandStatusResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
