using AutoMapper;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Interns.Commands;
using Infrastructure.Interns.ViewModels;

namespace Infrastructure.Interns.Profiles
{
    public class InternProfile : Profile, IProfileRegister
    {
        public InternProfile()
        {
            CreateMap<CreateInternVm, CreateInternCommand>().ReverseMap();
            CreateMap<Intern, GetInternVm>().ReverseMap();
            CreateMap<Intern, CreateInternCommand>().ReverseMap();
            CreateMap<UpdateInternCommand, Intern>().ReverseMap();
        }
    }
}
