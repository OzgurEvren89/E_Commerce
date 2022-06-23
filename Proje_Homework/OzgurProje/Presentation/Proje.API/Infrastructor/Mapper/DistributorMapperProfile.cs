using AutoMapper;
using Proje.Common.DTOs.Distributor;
using Proje.Common.Extensions;
using Proje.Model.Entities;



namespace Proje.API.Infrastructor.Mapper
{
    public class DistributorMapperProfile : Profile
    {
        public DistributorMapperProfile()
        {
            CreateMap<Distributor, DistributorRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Distributor, DistributorResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
