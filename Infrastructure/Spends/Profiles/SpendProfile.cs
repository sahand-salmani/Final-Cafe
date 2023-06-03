using AutoMapper;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Spends.Commands;
using Infrastructure.Spends.ViewModels;

namespace Infrastructure.Spends.Profiles
{
    public class SpendProfile : Profile, IProfileRegister
    {
        public SpendProfile()
        {
            CreateMap<GetSpendVm, Spend>().ReverseMap();
            CreateMap<CreateSpendVm, CreateSpendCommand>().ReverseMap();
            CreateMap<CreateSpendVm, Spend>().ReverseMap();
            CreateMap<EditSpendVm, Spend>().ReverseMap();
        }
    }
}
