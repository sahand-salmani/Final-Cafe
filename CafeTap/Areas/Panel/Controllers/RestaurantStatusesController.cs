using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using Infrastructure.Restaurants.Queries;
using Infrastructure.RestaurantStatuses.Commands;
using Infrastructure.RestaurantStatuses.Queries;
using Infrastructure.RestaurantStatuses.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    public class RestaurantStatusesController : MyController
    {

        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllRestaurantStatusQuery(page, 20);
            var model = await Mediator.Send(query);
            return View(model);
        }


        [HttpGet]
        [Route("")]
        [Route("{id:int:min(1)}/{page:int:min(1)}")]
        public async Task<IActionResult> Restaurants(int id, int page = 1)
        {
            var query = new GetRestaurantsOfStatusQuery(id, page, 20);
            var result = await Mediator.Send(query);
            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRestaurantStatusVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new CreateRestaurantStatusCommand(model);
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
            var query = new GetRestaurantStatusToUpdateQuery(id);
            EditRestaurantStatusVm model = await Mediator.Send(query);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditRestaurantStatusVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new UpdateRestaurantStatusCommand(model);
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
            var command = new DeleteRestaurantStatusCommand(id);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
