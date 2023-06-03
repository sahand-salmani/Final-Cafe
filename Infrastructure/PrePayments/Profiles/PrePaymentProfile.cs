using AutoMapper;
using Domain.Models;
using Infrastructure.PrePayments.Commands;
using Infrastructure.PrePayments.ViewModels;
using Infrastructure.Common;

namespace Infrastructure.PrePayments.Profiles
{
    public class PrePaymentProfile : Profile, IProfileRegister
    {
        public PrePaymentProfile()
        {
            CreateMap<CreatePrePaymentCommand, PrePayment>().ReverseMap();
            CreateMap<GetPrePaymentVm, PrePayment>().ReverseMap()
                .ForMember(e => e.EmployeeName, des => des.MapFrom(q => q.Employee.FullName))
                .ForMember(e => e.EmployeeId, des => des.MapFrom(q => q.Employee.Id));

            CreateMap<CreatePrePaymentVm, PrePayment>().ReverseMap();
            CreateMap<EditPrePaymentVm, PrePayment>().ReverseMap();
        }
    }
}
