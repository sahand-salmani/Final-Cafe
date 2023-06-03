using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using Infrastructure.RestaurantContacts.Commands;
using Infrastructure.RestaurantContacts.Queries;
using Infrastructure.RestaurantContacts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("panel")]
    [Route("[area]/[controller]/[action]")]
    public class RestaurantContactsController : MyController
    {
        [HttpGet]
        public async Task<IActionResult> RestaurantContacts(int id)
        {
            var query = new GetRestaurantContactsByRestaurantIdQuery(id);
            var result = await Mediator.Send(query);
            return View(result);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = new CreateRestaurantContactDetailVm
            {
                RestaurantId = id
            };


            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Add(CreateRestaurantContactDetailVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new CreateRestaurantContactCommand(model);
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                AddError(result.Errors);
            }

            return RedirectToAction("Index", "Restaurants");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var query = new GetRestaurantContactToUpdateQuery(id);
            return View(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateRestaurantContactVm model)
        {
            var command = new UpdateRestaurantContactCommand(model);
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }

            return RedirectToAction(nameof(RestaurantContacts), "RestaurantContacts", new { id = result.Entity });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id, int restaurantId)
        {
            var command = new DeleteRestaurantContractQuery(id, restaurantId);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return RedirectToAction(nameof(RestaurantContacts), new { id = result.Entity });
            }

            
            return RedirectToAction(nameof(RestaurantContacts), new { id = result.Entity });

        }
    }
}
