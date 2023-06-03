using AutoMapper;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.RestaurantMeetings.ViewModels;

namespace Infrastructure.RestaurantMeetings.Profiles
{
    public class RestaurantMeetingProfile : Profile, IProfileRegister
    {
        public RestaurantMeetingProfile()
        {
            CreateMap<UpdateRestaurantMeetingVm, RestaurantMeeting>().ReverseMap();
            CreateMap<CreateRestaurantMeetingVm, RestaurantMeeting>().ReverseMap();
            CreateMap<GetRestaurantMeetingVm, RestaurantMeeting>().ReverseMap();
            CreateMap<CreateMeetingVm, RestaurantMeeting>().ReverseMap();
            CreateMap<MeetingNotificationVm, RestaurantMeeting>().ReverseMap();

        }
    }
}
