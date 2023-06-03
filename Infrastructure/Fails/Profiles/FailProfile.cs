using AutoMapper;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Fails.Commands;
using Infrastructure.Fails.ViewModels;

namespace Infrastructure.Fails.Profiles
{
    public class FailProfile : Profile, IProfileRegister
    {
        public FailProfile()
        {
            CreateMap<Fail, GetFailsVm>().ReverseMap().ForMember(e => e.Employee, t => t.MapFrom(q => q.Employee));

            CreateMap<Fail, CreateFailCommand>().ReverseMap();

            CreateMap<UpdateFailVm, Fail>().ReverseMap();
        }
    }
}
