using CafeTap.Controllers.Base;
using Infrastructure.Common.Settings;
using Infrastructure.Settings.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    public class SettingsController : MyController
    {
        [HttpGet]
        public IActionResult DashBoardSettings()
        {
            DashboardSettingsVm model = DashboardSetting.GetModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult DashBoardSettings(DashboardSettingsVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            DashboardSetting.ApplyDashboardSettingChanges(model);

            SuccessMessage("Dəyişiklər edildi!");
            return RedirectToAction("Index", "Dashboard", new { area = "Panel" });
        }

    }
}
