using AutoMapper;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.EmployeeFaults.ViewModels;

namespace Infrastructure.EmployeeFaults.Profiles
{
    public class EmployeeFaultProfile : Profile, IProfileRegister
    {
        public EmployeeFaultProfile()
        {
            CreateMap<CreateEmployeeFaultVm, EmployeeFault>().ReverseMap();
            CreateMap<UpdateEmployeeFaultVm, EmployeeFault>().ReverseMap();
        }
    }
}
