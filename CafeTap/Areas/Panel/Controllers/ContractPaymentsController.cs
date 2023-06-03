using System;
using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using Infrastructure.ContractPayments.Commands;
using Infrastructure.ContractPayments.Queries;
using Infrastructure.ContractPayments.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    public class ContractPaymentsController : MyController
    {

        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllContractPaymentsQuery(page, 10);
            var result = await Mediator.Send(query);
            return View(result);
        }


        [HttpGet]
        [Route("")]
        [Route("{id:int:min(1)}/{page:int:min(1)}")]
        public async Task<IActionResult> ContractPayments(int id, int page = 1)
        {
            var query = new GetContractPaymentsQuery(id, page, 10);
            var result = await Mediator.Send(query);
            return View(result);
        }



        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = new CreateContractPaymentVm()
            {
                ContractId = id,
                PaidAt = DateTime.Now
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateContractPaymentVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new CreateContractPaymentCommand(model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                return View(model);
            }

            return RedirectToAction(nameof(Index));

        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var query = new GetContractPaymentToUpdateQuery(id);
            var model = await Mediator.Send(query);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateContractPaymentVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new UpdateContractPaymentCommand(model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }

            return RedirectToAction("Index", "Restaurants");
        }





        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteContractPaymentCommand(id);
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                //TODO: HANDLE
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
