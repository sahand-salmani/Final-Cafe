using CafeTap.Controllers.Base;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.PrePayments.Commands;
using Infrastructure.PrePayments.Queries;
using Infrastructure.PrePayments.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    public class PrePaymentController : MyController
    {
        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page =1)
        {
            var query = new GetAllPrePaymentsQuery(page, 20);
            PaginatedList<PrePayment> result = await Mediator.Send(query);
            return View(result);
        }

        [HttpGet]
        [Route("")]
        [Route("{id:int:min(1)}/{page:int:min(1)}")]
        public async Task<IActionResult> GetEmployeePrePayments(int id, int page = 1)
        {
            var model = new GetPrePaymentsOfEmployeeQuery(id, page, 20);
            var result = await Mediator.Send(model);

            return View(result);
        }


        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = new CreatePrePaymentVm()
            {
                EmployeeId = id,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatePrePaymentVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var command = new CreatePrePaymentCommand(model);

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
            var model = new GetPrePaymentToUpdateQuery(id);
            var result = await Mediator.Send(model);

            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Update(int id, EditPrePaymentVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new EditPrePaymentCommand(model, id);
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
            var command = new DeletePrePaymentCommand(id);
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
