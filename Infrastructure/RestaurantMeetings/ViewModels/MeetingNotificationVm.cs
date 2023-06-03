using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.RestaurantMeetings.ViewModels
{
    public class MeetingNotificationVm
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        [DataType(DataType.Date)]
        public DateTime HappensAt { get; set; }
        public string Remaining { get; set; }
        public string Person { get; set; }
    }
}
