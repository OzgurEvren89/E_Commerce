using AutoMapper;
using Proje.Common.DTOs.InstallmentRate;
using Proje.Common.Extensions;
using Proje.Web.UI.Areas.Admin.Models.InstallmentRateViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Infrasructure.Mappers
{
    public class InstallmentRateMapperProfile : Profile
    {
        public InstallmentRateMapperProfile()
        {
            CreateMap<InstallmentRateViewModel, InstallmentRateRequest>()
               .ReverseMap()
               .IgnoreAllNonExisting()
               .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<InstallmentRateViewModel, InstallmentRateResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateInstallmentRateViewModel, InstallmentRateRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateInstallmentRateViewModel, InstallmentRateResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateInstallmentRateViewModel, InstallmentRateRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateInstallmentRateViewModel, InstallmentRateResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
