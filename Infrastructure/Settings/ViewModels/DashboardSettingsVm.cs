using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Settings.ViewModels
{
    public class DashboardSettingsVm
    {
        [Required, Range(1, 100)] public int LeastRemainingMeetingDay { get; set; }
        [Required, Range(1, 100)] public int LeastRemainingMeetingCount { get; set; }
        [Required, Range(1, 100)] public int ContractEndNotificationDay { get; set; }
        [Required, Range(1, 100)] public int ContractEndNotificationCount { get; set; }
    }
}
