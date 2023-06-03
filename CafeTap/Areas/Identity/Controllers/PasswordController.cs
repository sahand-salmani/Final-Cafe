using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using Infrastructure.Users.Commands;
using Infrastructure.Users.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class PasswordController : MyController
    {

        [HttpGet]
        public IActionResult ChangePassword(string id)
        {
            var model = new ChangePasswordVm()
            {
                Id = id,
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(string id,ChangePasswordVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (id != model.Id)
            {
                FailMessages("Səhv baş verdi");
                return View(model);
            }

            var command = new ChangeUserPasswordCommand(model);
            var result = await Mediator.Send(command);

            if (result.Success)
            {
                SuccessMessage(result.Entity);
                return RedirectToAction("Index", "Dashboard", new { Area = "Panel" });
            }

            AddError(result.Errors);
            return View(model);
        }
    }
}
