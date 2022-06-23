using AutoMapper;
using Proje.Common.DTOs.OrderStatus;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class OrderStatusMapperProfile : Profile
    {
        public OrderStatusMapperProfile()
        {
            CreateMap<OrderStatus, OrderStatusRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<OrderStatus, OrderStatusResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
