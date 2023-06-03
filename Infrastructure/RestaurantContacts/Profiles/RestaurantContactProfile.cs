using AutoMapper;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.RestaurantContacts.ViewModels;

namespace Infrastructure.RestaurantContacts.Profiles
{
    public class RestaurantContactProfile : Profile, IProfileRegister
    {
        public RestaurantContactProfile()
        {
            CreateMap<CreateRestaurantContactVm, RestaurantContact>().ReverseMap();
            CreateMap<GetRestaurantContactVm, RestaurantContact>().ReverseMap();
            CreateMap<UpdateRestaurantContactVm, RestaurantContact>().ReverseMap();
        }
    }
}
