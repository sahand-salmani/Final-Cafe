using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Positions.Commands;
using Infrastructure.Positions.Queries;
using Infrastructure.Positions.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    [Authorize(Policy = ClaimsList.Employee)]

    public class PositionsController : MyController
    {
        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllPositionsQuery(page, 20);
            PaginatedList<Position> result = await Mediator.Send(query);
            return View(result);
        }


        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetPositionByIdQuery(id);
            var result = await Mediator.Send(query);
            if (result is null)
            {
                //TODO: ADD LATER
                return View("NotFound");
            }
            return View(result);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreatePositionCommand model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            OperationResult<int> result = await Mediator.Send(model);
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
            GetPositionByIdQuery query = new GetPositionByIdQuery(id);
            GetPositionVm result = await Mediator.Send(query);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, GetPositionVm model)
        {
            var command = new UpdatePositionCommand(id, model);
            OperationResult<GetPositionVm> result = await Mediator.Send(command);
            if (result.Success)
            {
                return RedirectToAction(nameof(Index));
            }

            ErrorHandler();
            return View(command.Model);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePositionCommand(id);
            var result = await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }


        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> CheckPositionExists(string name)
        {
            var query = new CheckPositionExistsQuery(name);
            var result = await Mediator.Send(query);

            return result ? Json($"Position {name} already exists") : Json(true);
        }
    }
}
