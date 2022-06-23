using AutoMapper;
using Proje.Common.DTOs.CurrencyValue;
using Proje.Common.Extensions;
using Proje.Web.UI.Areas.Admin.Models.CurrencyValueViewModels;

namespace Proje.Web.UI.Infrasructure.Mappers
{
    public class CurrencyValueMapperProfile : Profile
    {
        public CurrencyValueMapperProfile()
        {
            CreateMap<CurrencyValueViewModel, CurrencyValueRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CurrencyValueViewModel, CurrencyValueResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateCurrencyValueViewModel, CurrencyValueRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateCurrencyValueViewModel, CurrencyValueResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateCurrencyValueViewModel, CurrencyValueRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateCurrencyValueViewModel, CurrencyValueResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
