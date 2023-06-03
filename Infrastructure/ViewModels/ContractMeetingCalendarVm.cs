using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Contracts.ViewModels;
using Infrastructure.RestaurantMeetings.ViewModels;

namespace Infrastructure.ViewModels
{
    public class ContractMeetingCalendarVm
    {
        public List<ContractCalendarVm> ContractCalendarVm { get; set; }
        public List<MeetingCalendarVm> MeetingCalendarVm { get; set; }
    }
}
