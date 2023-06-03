using System.Threading.Tasks;
using CafeTap.Areas.Panel.Controllers;
using CafeTap.Controllers.Base;
using Infrastructure.Identity.Commands;
using Infrastructure.Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Areas.Identity.Controllers
{
    [Area("Identity")]
    [AllowAnonymous]
    public class LoginController : MyController
    {
        [HttpGet]
        [Route("Account/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Account/Login")]
        [Route("Account/Login/{returnUrl?}")]
        public async Task<IActionResult> Login(LoginVm model, string returnUrl)
        {
            var command = new LoginUserCommand(model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }


            if (string.IsNullOrEmpty(returnUrl))
                return RedirectToAction(nameof(DashboardController.Index), "Dashboard", new { area = "Panel" });


            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(nameof(DashboardController.Index), "Dashboard", new { area = "Panel" });
        }


        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            var command = new SignOutCommand();
            await Mediator.Send(command);

            return RedirectToAction(nameof(Login));
        }
    }
}
