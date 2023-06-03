using CafeTap.Controllers.Base;
using Infrastructure.Partners.Commands;
using Infrastructure.Partners.Queries;
using Infrastructure.Partners.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataAccess.Pagination;
using Domain.Models;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("panel")]
    [Route("[area]/[controller]/[action]")]

    public class PartnersController : MyController
    {

        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllPartnersQuery(page, 20);
            PaginatedList<Partner> result = await Mediator.Send(query);



            return View(result);
        }


        public async Task<IActionResult> Search(string name, int page = 1)
        {
            SearchParameter(name);
            var query = new GetPartnersBySearchNameQuery(name, page, 20);
            var result = await Mediator.Send(query);

            return View(result);
        }


        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreatePartnersVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new CreatePartnersCommand(model);
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
            var query = new GetPartnersToUpdateQuery(id);
            var result = await Mediator.Send(query);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, EditPartnersVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new UpdatePartnersCommand(model);
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
            var command = new DeletePartnersCommand(id);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
