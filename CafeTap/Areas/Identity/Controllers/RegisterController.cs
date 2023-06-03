using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using Infrastructure.Common;
using Infrastructure.Users.Commands;
using Infrastructure.Users.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Areas.Identity.Controllers
{
    [Area("Identity")]
    [AllowAnonymous]
    public class RegisterController : MyController
    {

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(AddNewUserVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new CreateUserWithTokenCommand(model);
            OperationResult<string> result = await Mediator.Send(command);

            if (!result.Success)
            {
                return View(model);
            }


            return RedirectToAction("index", "Dashboard", new { area = "Panel" });


        }
    }
}
