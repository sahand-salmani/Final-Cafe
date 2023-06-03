using AutoMapper;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.ContractPayments.ViewModels;

namespace Infrastructure.ContractPayments.Profiles
{
    public class ContractPaymentProfile : Profile, IProfileRegister
    {
        public ContractPaymentProfile()
        {
            CreateMap<ContractPayment, CreateContractPaymentVm>().ReverseMap();
            CreateMap<UpdateContractPaymentVm, ContractPayment>().ReverseMap();
            CreateMap<GetContractPaymentVm, ContractPayment>().ReverseMap();
        }
    }
}
