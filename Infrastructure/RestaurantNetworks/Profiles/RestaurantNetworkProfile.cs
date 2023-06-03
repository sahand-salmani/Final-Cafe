using AutoMapper;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.RestaurantNetworks.ViewModels;

namespace Infrastructure.RestaurantNetworks.Profiles
{
    public class RestaurantNetworkProfile : Profile, IProfileRegister
    {
        public RestaurantNetworkProfile()
        {
            CreateMap<CreateRestaurantNetworkVm, RestaurantNetwork>().ReverseMap();
            CreateMap<EditRestaurantNetworkVm, RestaurantNetwork>().ReverseMap();
        }
    }
}
