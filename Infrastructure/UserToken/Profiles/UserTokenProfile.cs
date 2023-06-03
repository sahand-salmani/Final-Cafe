using AutoMapper;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.UserToken.ViewModels;

namespace Infrastructure.UserToken.Profiles
{
    public class UserTokenProfile : Profile, IProfileRegister
    {
        public UserTokenProfile()
        {
            CreateMap<CreateUserTokenVm, UserRegisterToken>().ReverseMap();
        }
    }
}
