using AutoMapper;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.RestaurantStatuses.ViewModels;

namespace Infrastructure.RestaurantStatuses.Profiles
{
    public class RestaurantStatusProfile : Profile, IProfileRegister
    {
        public RestaurantStatusProfile()
        {
            CreateMap<CreateRestaurantStatusVm, RestaurantStatus>().ReverseMap();
            CreateMap<EditRestaurantStatusVm, RestaurantStatus>().ReverseMap();
        }
    }
}
