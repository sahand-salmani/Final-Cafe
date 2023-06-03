using AutoMapper;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Employees.Commands;
using Infrastructure.Employees.ViewModels;

namespace Infrastructure.Employees.Profiles
{
    public class EmployeeProfile : Profile, IProfileRegister
    {
        public EmployeeProfile()
        {
            CreateMap<GetEmployeeVm, Employee>().ReverseMap()
                .ForMember(e => e.EmployeePayments, des => des.MapFrom(q => q.EmployeePayments)).ForMember(e => e.Position, des => des.MapFrom(q => q.Position));

            CreateMap<CreateEmployeeCommand, Employee>().ReverseMap();
            CreateMap<CreateEmployeeVm, CreateEmployeeCommand>().ReverseMap();
            CreateMap<EditEmployeeVm, Employee>().ReverseMap();
            CreateMap<CreateEmployeeVm, Employee>().ReverseMap();
        }
    }
}
