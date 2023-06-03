using CafeTap.Controllers.Base;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Spends.Commands;
using Infrastructure.Spends.Queries;
using Infrastructure.Spends.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Infrastructure.Common;
using Microsoft.AspNetCore.Authorization;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("panel")]
    [Route("[area]/[controller]/[action]")]
    [Authorize(Policy = ClaimsList.Stends)]
    public class SpendsController : MyController
    {
        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllSpendsQuery(page, 2);
            PaginatedList<Spend> result = await Mediator.Send(query);
            return View(result);
        }

        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> SearchByName(string name, int page = 1)
        {
            SearchParameter(name);
            var query = new GetSpendsByEmployeeNameSearchQuery(name, page, 10);
            var model = await Mediator.Send(query);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetSpendByIdQuery(id);
            var result = await Mediator.Send(query);

            if(result is null)
            {
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

        public async Task<IActionResult> Add(CreateSpendVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new CreateSpendCommand(model);
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
            var query = new GetSpendToUpdateQuery(id);
            var result = await Mediator.Send(query);
            return View(result);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id, EditSpendVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new UpdateSpendCommand(id, model);
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
            var command = new DeleteSpendCommand(id);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
