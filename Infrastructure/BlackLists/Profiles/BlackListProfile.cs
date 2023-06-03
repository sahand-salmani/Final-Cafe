using AutoMapper;
using Domain.Models;
using Infrastructure.BlackLists.ViewModels;
using Infrastructure.Common;

namespace Infrastructure.BlackLists.Profiles
{
    public class BlackListProfile : Profile, IProfileRegister
    {
        public BlackListProfile()
        {
            CreateMap<CreateBlackListVm, BlackList>().ReverseMap();
            CreateMap<EditBlackListVm, BlackList>().ReverseMap();
        }
    }
}
