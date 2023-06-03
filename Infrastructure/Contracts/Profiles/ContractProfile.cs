using AutoMapper;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Contracts.ViewModels;

namespace Infrastructure.Contracts.Profiles
{
    public class ContractProfile : Profile, IProfileRegister
    {
        public ContractProfile()
        {
            CreateMap<CreateContractVm, Contract>().ReverseMap();
            CreateMap<UpdateContractVm, Contract>().ReverseMap();

            CreateMap<GetContractVm, Contract>().ReverseMap()
                .ForMember(e => e.Employee, des => des.MapFrom(q => q.Employee))
                .ForMember(e => e.Restaurant, des => des.MapFrom(q => q.Restaurant));

            CreateMap<ContractNotificationVm, Contract>().ReverseMap();
            CreateMap<GetContractVm, Contract>().ReverseMap();
        }
    }
}
