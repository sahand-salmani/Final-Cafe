using AutoMapper;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Positions.Commands;
using Infrastructure.Positions.ViewModels;

namespace Infrastructure.Positions.Profiles
{
    public class PositionProfile : Profile, IProfileRegister
    {
        public PositionProfile()
        {
            CreateMap<GetPositionVm, Position>().ReverseMap()
                .ForMember(e => e.Employees, from => from.MapFrom(q => q.Employees));

            CreateMap<CreatePositionCommand, Position>().ReverseMap();
        }
    }
}
