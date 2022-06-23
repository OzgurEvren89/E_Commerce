using AutoMapper;
using Proje.Common.DTOs.OrderRefundDemand;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class OrderRefundDemandMapperProfile : Profile
    {
        public OrderRefundDemandMapperProfile()
        {
            CreateMap<OrderRefundDemand, OrderRefundDemandRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<OrderRefundDemand, OrderRefundDemandResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
