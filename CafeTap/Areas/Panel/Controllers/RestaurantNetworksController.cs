using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using Infrastructure.RestaurantNetworks.Commands;
using Infrastructure.RestaurantNetworks.Queries;
using Infrastructure.RestaurantNetworks.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Areas.Panel.Controllers
{

    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    public class RestaurantNetworksController : MyController
    {
        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var model = new GetAllRestaurantNetworkQuery(page, 20);
            var result = await Mediator.Send(model);

            return View(result);
        }

        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> NetworkRestaurants(int id, int page = 1)
        {
            SearchParameter(id.ToString());
            var model = new GetAllRestaurantsOfNetworkQuery(id, page, 20);
            var result = await Mediator.Send(model);

            return View(result);
        }

        [HttpGet]
        [Route("")]
        [Route("{name}/{page:int:min(1)}")]
        public async Task<IActionResult> SearchByName(string name, int page = 1)
        {
            SearchParameter(name);
            var query = new GetRestaurantNetworkBySearchQuery(name, page, 20);
            var result = await Mediator.Send(query);

            return View(result);
        }




        [HttpGet]
        public IActionResult Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(CreateRestaurantNetworkVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new CreateRestaurantNetworkCommand(model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }

            SuccessMessage("Restaurant network creation was successful");

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var query = new GetRestaurantNetworkToUpdateQuery(id);
            var result = await Mediator.Send(query);

            if (result is null)
            {
                return View("NotFound");
            }

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditRestaurantNetworkVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new UpdateRestaurantNetworkCommand(model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }

            SuccessMessage("Network edit was successful!");
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteRestaurantNetworkCommand(id);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                FailMessages(result.Errors);
                return RedirectToAction(nameof(Index));
            }

            SuccessMessage("Network deleted successfully");
            return RedirectToAction(nameof(Index));
        }
    }
}
