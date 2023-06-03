using AutoMapper;
using Domain.Users;
using Infrastructure.Common;
using Infrastructure.Users.ViewModels;

namespace Infrastructure.Users.Profiles
{
    public class UserProfile : Profile, IProfileRegister
    {
        public UserProfile()
        {
            CreateMap<GetUserVm, ApplicationUser>().ReverseMap().ForMember(e => e.UserRoles, des => des.MapFrom(q => q.Roles));

            CreateMap<UserRoleVm, ApplicationUserRole>().ReverseMap();

            CreateMap<EditUserRoleVm, ApplicationUser>().ReverseMap();
            CreateMap<EditUserVm, ApplicationUser>().ReverseMap();
        }
    }
}
