using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using Infrastructure.Common;
using Infrastructure.EmployeePunishments.Commands;
using Infrastructure.EmployeePunishments.Queries;
using Infrastructure.EmployeePunishments.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    [Authorize(Policy = ClaimsList.Employee)]

    public class EmployeePunishmentsController : MyController
    {
        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllEmployeePunishmentsQuery(page, 10);
            var model = await Mediator.Send(query);
            return View(model);
        }

        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> SearchByName(string name, int page = 1)
        {
            SearchParameter(name);
            var query = new GetEmployeePunishmentBySearchQuery(name, page, 10);
            var model = await Mediator.Send(query);

            return View(model);
        }


        [HttpGet]
        [Route("")]
        [Route("{id:int:min(1)}/{page:int:min(1)}")]
        public async Task<IActionResult> EmployeePunishments(int id, int page=1)
        {
            SearchParameter(id.ToString());
            var query = new GetPunishmentsOfEmployeeQuery(id, page, 20);
            var model = await Mediator.Send(query);

            return View(model);
        }


        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = new CreateEmployeePunishmentVm()
            {
                EmployeeId = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateEmployeePunishmentVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new CreateEmployeePunishmentCommand(model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }

            return RedirectToAction(nameof(EmployeePunishments), new {id=result.Entity, page=1});
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var command = new GetEmployeePunishmentToUpdateQuery(id);
            var result = await Mediator.Send(command);

            if (result is null)
            {
                return View("NotFound");
            }

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditEmployeePunishmentVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new UpdateEmployeePunishmentCommand(model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }

            return RedirectToAction(nameof(EmployeePunishments), new { id = result.Entity });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteEmployeePunishmentCommand(id);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return RedirectToAction(nameof(EmployeePunishments), new { id = result.Entity, page = 1 });
            }

            return RedirectToAction(nameof(EmployeePunishments), new { id = result.Entity, page = 1 });
        }
    }
}
