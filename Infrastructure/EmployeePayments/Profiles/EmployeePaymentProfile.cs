using AutoMapper;
using Domain.Models;
using Infrastructure.EmployeePayments.Commands;
using Infrastructure.EmployeePayments.ViewModels;
using Infrastructure.Common;

namespace Infrastructure.EmployeePayments.Profiles
{
    public class EmployeePaymentProfile : Profile, IProfileRegister
    {
        public EmployeePaymentProfile()
        {
            CreateMap<CreateEmployeePaymentCommand, EmployeePayment>().ReverseMap();
            CreateMap<CreateEmployeePaymentVm, CreateEmployeePaymentCommand>().ReverseMap();
            CreateMap<CreateEmployeePaymentVm, EmployeePayment>().ReverseMap();
            CreateMap<UpdateEmployeePaymentVm, EmployeePayment>().ReverseMap();
            CreateMap<GetEmployeePaymentVm, EmployeePayment>().ReverseMap();

        }
    }
}
