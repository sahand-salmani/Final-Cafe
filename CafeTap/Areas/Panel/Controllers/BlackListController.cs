using CafeTap.Controllers.Base;
using Infrastructure.BlackLists.Commands;
using Infrastructure.BlackLists.Queries;
using Infrastructure.BlackLists.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("panel")]
    [Route("[area]/[controller]/[action]")]
    public class BlackListController : MyController
    {
        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            
            var query = new GetAllBlackListQuery( page, 20);
            var model = await Mediator.Send(query);
            return View(model);
        }

        [HttpGet]
        [Route("")]
        [Route("{name}/{page:int:min(1)}")]
        public async Task<IActionResult> SearchByName(string name, int page = 1)
        {
            SearchParameter(name);
            var query = new GetAllBlackListsBySearchNameQuery(name,page, 20);
            var model = await Mediator.Send(query);
            return View(model);
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBlackListVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new CreateBlackListCommand(model);
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
            var query = new GetBlackListToUpdateQuery(id);
            EditBlackListVm model = await Mediator.Send(query);

            if(model is null)
            {
                return View("NotFound");
            }

            return View(model);
        }
       
        [HttpPost]

        public async Task<IActionResult> Update(EditBlackListVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new EditBlackListCommand(model);
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
            var command = new DeleteBlackListCommand(id);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return RedirectToAction(nameof(Index));
            }
            SuccessMessage("Black list deleted successfully!");
            return RedirectToAction(nameof(Index));
        }
    }
}
