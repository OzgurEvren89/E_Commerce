using AutoMapper;
using Proje.Common.DTOs.OrderRefundDemand;
using Proje.Common.Extensions;
using Proje.Web.UI.Areas.Admin.Models.OrderRefundDemandViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Infrasructure.Mappers
{
    public class OrderRefundDemandMapperProfile : Profile
    {
        public OrderRefundDemandMapperProfile()
        {
            CreateMap<OrderRefundDemandViewModel, OrderRefundDemandRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<OrderRefundDemandViewModel, OrderRefundDemandResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateOrderRefundDemandViewModel, OrderRefundDemandRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateOrderRefundDemandViewModel, OrderRefundDemandResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateOrderRefundDemandViewModel, OrderRefundDemandRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateOrderRefundDemandViewModel, OrderRefundDemandResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
