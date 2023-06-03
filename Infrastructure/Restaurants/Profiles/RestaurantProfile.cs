using System.Collections.Generic;
using AutoMapper;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Restaurants.Commands;
using Infrastructure.Restaurants.ViewModels;

namespace Infrastructure.Restaurants.Profiles
{
    public class RestaurantProfile : Profile, IProfileRegister
    {
        public RestaurantProfile()
        {
            CreateMap<CreateRestaurantCommand, Restaurant>().ReverseMap();
            CreateMap<GetRestaurantVm, Restaurant>().ReverseMap();
            CreateMap<CreateRestaurantVm, Restaurant>().ReverseMap();
            CreateMap<UpdateRestaurantVm, Restaurant>().ReverseMap();
            CreateMap<GetRestaurantDebtVm, Restaurant>().ReverseMap();
            CreateMap<PaginatedList<Restaurant>, List<Restaurant>>().ReverseMap();
        }
    }
}
