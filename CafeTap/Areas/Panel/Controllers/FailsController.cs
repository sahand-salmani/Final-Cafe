using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Employees.Queries;
using Infrastructure.Fails.Commands;
using Infrastructure.Fails.Queries;
using Infrastructure.Fails.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    [Authorize(Policy = ClaimsList.Stends)]
    public class FailsController : MyController
    {
        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllFailsQuery(page, 1);
            PaginatedList<Fail> result = await Mediator.Send(query);
            return View(result);
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetFailByIdQuery(id);
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
            var model = new CreateFailCommand();
            var selectListQuery = new GetEmployeeSelectListQuery(0);
            var selectListResult = await Mediator.Send(selectListQuery);
            model.SelectList = selectListResult;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateFailCommand model)
        {
            if (!ModelState.IsValid)
            {
                var selectListQuery = new GetEmployeeSelectListQuery(model.EmployeeId);
                var selectListResult = await Mediator.Send(selectListQuery);
                model.SelectList = selectListResult;
                return View(model);
            }
            
            var result = await Mediator.Send(model);
            if (!result.Success)
            {
                ErrorHandler();
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var query = new GetFailToUpdateQuery(id);
            UpdateFailVm result = await Mediator.Send(query);
            var selectListQuery = new GetEmployeeSelectListQuery(result.EmployeeId);
            result.SelectList = await Mediator.Send(selectListQuery);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateFailVm model)
        {
            var selectListQuery = new GetEmployeeSelectListQuery(model.EmployeeId);
            model.SelectList = await Mediator.Send(selectListQuery);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new UpdateFailCommand(id, model);
            OperationResult<GetFailsVm> result = await Mediator.Send(command);
            if (!result.Success)
            {
                ErrorHandler();
                return View(command.Model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteFailCommand(id);
            OperationResult<Unit> result = await Mediator.Send(command);
            if (!result.Success)
            {
                // handle later
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
