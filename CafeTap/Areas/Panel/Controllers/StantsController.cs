using CafeTap.Controllers.Base;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Stants.Commands;
using Infrastructure.Stants.Queries;
using Infrastructure.Stants.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Infrastructure.Common;
using Infrastructure.Restaurants.Queries;
using Microsoft.AspNetCore.Authorization;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("panel")]
    [Route("[area]/[controller]/[action]")]
    [Authorize(Policy = ClaimsList.Stends)]
    public class StantsController : MyController
    {
        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllStantsQuery(page, 20);
            PaginatedList<Stant> result = await Mediator.Send(query);
            return View(result);
        }


        [HttpGet]
        [Route("")]
        [Route("{name}/{page:int:min(1)}")]
        public async Task<IActionResult> SearchByName(string name, int page=1)
        {
            var query = new GetStantsByNameSearchQuery(name, page, 20);
            return View(await Mediator.Send(query));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new CreateStantVm();
            var selectListQuery = new GetRestaurantsSelectListQuery(0);
            var selectListResult = await Mediator.Send(selectListQuery);
            model.SelectList = selectListResult;
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Add(CreateStantVm model)
        {
            var selectListQuery = new GetRestaurantsSelectListQuery(model.RestaurantId);
            var selectListResult = await Mediator.Send(selectListQuery);
            model.SelectList = selectListResult;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new CreateStantCommand(model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var model = new GetStantToUpdateQuery(id);
            UpdateStantVm result = await Mediator.Send(model);
            var selectList = new GetRestaurantsSelectListQuery(result.RestaurantId);
            var selectListResult = await Mediator.Send(selectList);
            result.SelectList = selectListResult;
            return View(result);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id,UpdateStantVm model)
        {
            var selectList = new GetRestaurantsSelectListQuery(model.Id);
            var selectListResult = await Mediator.Send(selectList);
            model.SelectList = selectListResult;

            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

            var command = new UpdateStantCommand(id, model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteStantCommand(id);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
