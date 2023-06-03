using AutoMapper;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.EmployeePunishments.ViewModels;

namespace Infrastructure.EmployeePunishments.Profiles
{
    public class EmployeePunishmentProfile : Profile, IProfileRegister
    {
        public EmployeePunishmentProfile()
        {
            CreateMap<CreateEmployeePunishmentVm, EmployeePunishment>().ReverseMap();
            CreateMap<EditEmployeePunishmentVm, EmployeePunishment>().ReverseMap();
        }
    }
}
