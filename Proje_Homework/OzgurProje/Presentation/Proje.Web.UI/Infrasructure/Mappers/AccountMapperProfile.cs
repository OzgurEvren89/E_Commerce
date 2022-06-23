using AutoMapper;
using Proje.Common.DTOs.Login;
using Proje.Common.DTOs.User;
using Proje.Common.Extensions;
using Proje.Web.UI.Models.AccountViewModels;

namespace Proje.Web.UI.Infrasructure.Mappers
{
    public class AccountMapperProfile : Profile
    {
        public AccountMapperProfile()
        {
            CreateMap<LoginViewModel, LoginRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateUserVM, UserRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
