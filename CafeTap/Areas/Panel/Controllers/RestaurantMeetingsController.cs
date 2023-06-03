using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.RestaurantMeetings.Commands;
using Infrastructure.RestaurantMeetings.Queries;
using Infrastructure.RestaurantMeetings.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Areas.Panel.Controllers
{

    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    public class RestaurantMeetingsController : MyController
    {

        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllRestaurantMeetingsQuery(page, 20);
            PaginatedList<RestaurantMeeting> result = await Mediator.Send(query);
            return View(result);
        }

        [HttpGet]
        [Route("")]
        [Route("{name}/{page:int:min(1)}")]
        public async Task<IActionResult> SearchByName(string name, int page = 1)
        {
            SearchParameter(name);
            var query = new GetRestaurantMeetingsBySearchQuery(name,page, 20);
            PaginatedList<RestaurantMeeting> result = await Mediator.Send(query);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetRestaurantMeetingByIdQuery(id);
            var model = await Mediator.Send(query);
            return View(model);
        }


        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = new CreateRestaurantMeetingVm()
            {
                RestaurantId = id
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateRestaurantMeetingVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new CreateRestaurantMeetingCommand(model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateMeetingVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new CreateMeetingQuery(model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }

            SuccessMessage("Meeting created successfully!");
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = new GetRestaurantMeetingToUpdateQuery(id);
            var result = await Mediator.Send(model);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateRestaurantMeetingVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new UpdateRestaurantMeetingCommand(model);
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
            var command = new DeleteRestaurantMeetingCommand(id);
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
