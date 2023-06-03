using Infrastructure.Settings.ViewModels;

namespace Infrastructure.Common.Settings
{
    public static class DashboardSetting
    {
        public static int ContractEndNotificationDay = 3;
        public static int ContractEndNotificationCount = 10;
        public static int LeastRemainingMeetingDay = 3;
        public static int LeastRemainingMeetingCount = 10;

        public static DashboardSettingsVm GetModel()
        {
            var model = new DashboardSettingsVm()
            {
                ContractEndNotificationCount = ContractEndNotificationCount,
                ContractEndNotificationDay = ContractEndNotificationDay,
                LeastRemainingMeetingDay = LeastRemainingMeetingDay,
                LeastRemainingMeetingCount = LeastRemainingMeetingCount
            };

            return model;
        }

        public static void ApplyDashboardSettingChanges(DashboardSettingsVm model)
        {
            DashboardSetting.ContractEndNotificationDay = model.ContractEndNotificationDay;
            DashboardSetting.ContractEndNotificationCount = model.ContractEndNotificationCount;
            DashboardSetting.LeastRemainingMeetingCount = model.LeastRemainingMeetingCount;
            DashboardSetting.LeastRemainingMeetingDay = model.LeastRemainingMeetingDay;
        }
    }
}
