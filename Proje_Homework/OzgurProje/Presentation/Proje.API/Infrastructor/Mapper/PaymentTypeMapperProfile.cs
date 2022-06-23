using AutoMapper;
using Proje.Common.DTOs.PaymentType;
using Proje.Common.Extensions;
using Proje.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.API.Infrastructor.Mapper
{
    public class PaymentTypeMapperProfile : Profile
    {
        public PaymentTypeMapperProfile()
        {
            CreateMap<PaymentType, PaymentTypeRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PaymentType, PaymentTypeResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
