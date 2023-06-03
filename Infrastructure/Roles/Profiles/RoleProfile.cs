using AutoMapper;
using Domain.Users;
using Infrastructure.Common;
using Infrastructure.Roles.ViewModels;

namespace Infrastructure.Roles.Profiles
{
    public class RoleProfile : Profile, IProfileRegister
    {
        public RoleProfile()
        {
            CreateMap<GetRoleVm, ApplicationRole>().ReverseMap().ForMember(e => e.Users, q => q.MapFrom(t => t.Users));

            CreateMap<ApplicationRole, UpdateRoleVm>();
        }
    }
}
