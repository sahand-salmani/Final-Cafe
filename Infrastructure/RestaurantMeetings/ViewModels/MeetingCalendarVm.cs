using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.RestaurantMeetings.ViewModels
{
    public class MeetingCalendarVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public DateTime Start { get; set; }
        public string Url { get; set; }

    }
}
