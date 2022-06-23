using AutoMapper;
using Proje.Common.DTOs.PhoneNumberType;
using Proje.Common.Extensions;
using Proje.Web.UI.Areas.Admin.Models.PhoneNumberTypeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Infrasructure.Mappers
{
    public class PhoneNumberTypeMapperProfile : Profile
    {
        public PhoneNumberTypeMapperProfile()
        {
            CreateMap<PhoneNumberTypeViewModel, PhoneNumberTypeRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PhoneNumberTypeViewModel, PhoneNumberTypeResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreatePhoneNumberTypeViewModel, PhoneNumberTypeRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreatePhoneNumberTypeViewModel, PhoneNumberTypeResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdatePhoneNumberTypeViewModel, PhoneNumberTypeRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdatePhoneNumberTypeViewModel, PhoneNumberTypeResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
