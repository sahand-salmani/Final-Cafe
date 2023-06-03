using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.RestaurantMeetings.ViewModels;
using MediatR;

namespace Infrastructure.RestaurantMeetings.Queries
{
    public class GetMeetingsCalendarQuery : IRequest<List<MeetingCalendarVm>>
    {
    }
}
