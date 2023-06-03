using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Interns.Commands;
using Infrastructure.Interns.Queries;
using Infrastructure.Interns.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    [Authorize(Policy = ClaimsList.Intern)]
    public class InternsController : MyController
    {

        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllInternsQuery(page, 20);
            PaginatedList<Intern> result = await Mediator.Send(query);
            return View(result);
        }


        [HttpGet]
        [Route("")]
        [Route("{name}/{page:int:min(1)}")]
        public async Task<IActionResult> SearchByName(string name, int page = 1)
        {
            SearchParameter(name);
            var query = new GetInternBySearchNameQuery(name,page, 20);
            PaginatedList<Intern> result = await Mediator.Send(query);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetInternByIdQuery(id);
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
            var model = new CreateInternCommand();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateInternCommand model)
        {
            if (!ModelState.IsValid)
            {
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
            GetInternByIdQuery query = GetInternByIdQuery.Get(id);
            var result = await Mediator.Send(query);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id,GetInternVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var command = UpdateInternCommand.Update(id, model);
            OperationResult<GetInternVm> result = await Mediator.Send(command);
            if (!result.Success)
            {
                ErrorHandler();
                return View(command.GetInternVm);
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteInternCommand(id);
            var result = await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }




    }
}
