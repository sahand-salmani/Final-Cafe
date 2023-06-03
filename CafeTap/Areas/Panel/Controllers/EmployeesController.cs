using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using Infrastructure.Common;
using Infrastructure.Employees.Commands;
using Infrastructure.Employees.Queries;
using Infrastructure.Employees.ViewModels;
using Infrastructure.Positions.Queries;
using Infrastructure.Statistics.IncomesSpends;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    [Authorize(Policy = ClaimsList.Employee)]
    public class EmployeesController : MyController
    {
        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllEmployeesQuery(page, 20);
            var result = await Mediator.Send(query);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeContractPaymentIncomeCurrentYear(int id)
        {
            var query = new IncomePerMonthByEmployeeQuery(id);
            var result = await Mediator.Send(query);

            return View(result);
        }


        [HttpGet]
        [Route("")]
        [Route("{name}/{page:int:min(1)}")]
        public async Task<IActionResult> Search(string name, int page=1)
        {
            SearchParameter(name);
            var query = new GetEmployeesBySearchNameQuery(page, 10, name);
            var result = await Mediator.Send(query);

            return View(result);
        }


        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetEmployeeByIdQuery(id);
            var result = await Mediator.Send(query);
            if (result is null)
            {
                //TODO: ADD LATER
                return View("NotFound");
            }
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new CreateEmployeeVm();
            var selectListQuery = new GetAllPositionSelectListQuery(0);
            var selectListResult = await Mediator.Send(selectListQuery);
            model.SelectList = selectListResult;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateEmployeeVm model)
        {
            if (!ModelState.IsValid)
            {
                var selectListQuery = new GetAllPositionSelectListQuery(model.PositionId);
                var selectListResult = await Mediator.Send(selectListQuery);
                model.SelectList = selectListResult;
                return View(model);
            }

            var command = new CreateEmployeeCommand(model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet()]
        public async Task<IActionResult> Update(int id)
        {
            var model = new GetEmployeeToUpdateQuery(id);
            EditEmployeeVm result = await Mediator.Send(model);
            var selectListQuery = new GetAllPositionSelectListQuery(result.PositionId);
            var selectListResult = await Mediator.Send(selectListQuery);
            result.SelectList = selectListResult;
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, EditEmployeeVm model)
        {
            if (!ModelState.IsValid)
            {
                var selectListQuery = new GetAllPositionSelectListQuery(model.Id);
                var selectListResult = await Mediator.Send(selectListQuery);
                model.SelectList = selectListResult;
                return View(model);
            }

            var command = new EditEmployeeCommand(id, model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteEmployeeCommand(id);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                //handle
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
