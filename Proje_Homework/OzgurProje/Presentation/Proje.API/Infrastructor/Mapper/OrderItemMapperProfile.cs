using AutoMapper;
using Proje.Common.DTOs.OrderItem;
using Proje.Common.Extensions;
using Proje.Model.Entities;

namespace Proje.API.Infrastructor.Mapper
{
    public class OrderItemMapperProfile : Profile
    {
        public OrderItemMapperProfile()
        {
            CreateMap<OrderItem, OrderItemRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<OrderItem, OrderItemResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
