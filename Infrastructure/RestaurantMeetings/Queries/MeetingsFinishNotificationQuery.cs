using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Common.Settings;
using Infrastructure.RestaurantMeetings.ViewModels;
using MediatR;

namespace Infrastructure.RestaurantMeetings.Queries
{
    public class MeetingsFinishNotificationQuery : IRequest<List<MeetingNotificationVm>>
    {
        public MeetingsFinishNotificationQuery()
        {
            Days = DashboardSetting.LeastRemainingMeetingDay;
            Count = DashboardSetting.LeastRemainingMeetingCount;
        }
        public int Days { get; set; }
        public int Count { get; set; }
    }
}
