using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using Infrastructure.Contracts.Commands;
using Infrastructure.Contracts.Queries;
using Infrastructure.Contracts.ViewModels;
using Infrastructure.Employees.Queries;
using Infrastructure.Products.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    public class ContractsController : MyController
    {
        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var model = new GetAllContractsQuery(page, 20);
            var result = await Mediator.Send(model);

            return View(result);
        }

        [HttpGet]
        [Route("")]
        [Route("{name}/{page:int:min(1)}")]
        public async Task<IActionResult> SearchByName(string name, int page = 1)
        {
            SearchParameter(name);
            var model = new GetRestaurantContractByNameSearchQuery(name, page, 20);
            var result = await Mediator.Send(model);
            return View(result);
        }



        [HttpGet]
        public IActionResult SearchByCity() => View();

        [HttpGet]
        [Route("")]
        [Route("{name}/{page:int:min(1)}")]
        public async Task<IActionResult> SearchByCityName(string name, int page = 1)
        {
            SearchParameter(name);
            var query = new GetContractsOfCityBySearchQuery(name, page, 20);
            var result = await Mediator.Send(query);

            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            var model = new CreateContractVm
            {
                RestaurantId = id
            };

            var empQuery = new GetEmployeeSelectListQuery(0);
            SelectList empSelectList = await Mediator.Send(empQuery);

            var prodQuery = new GetProductsMultiSelectListQuery(null);
            var prodMultiSelectList = await Mediator.Send(prodQuery);

            model.Employees = empSelectList;
            model.Products = prodMultiSelectList;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateContractVm model)
        {
            var empQuery = new GetEmployeeSelectListQuery(model.EmployeeId);
            SelectList empSelectList = await Mediator.Send(empQuery);

            var prodQuery = new GetProductsMultiSelectListQuery(model.ProductsId);
            var prodMultiSelectList = await Mediator.Send(prodQuery);

            model.Employees = empSelectList;
            model.Products = prodMultiSelectList;


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new CreateContractCommand(model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }

            return RedirectToAction("Index", "Restaurants");
        }

        [HttpGet]
        [Route("{id:int:min(1)}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetContractByIdQuery(id);
            var result = await Mediator.Send(query);
            if (result == null)
            {
                return View("NotFound");
            }
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var query = new GetContractToUpdateQuery(id);
            var model = await Mediator.Send(query);

            if (model == null)
            {
                return View("NotFound");
            }

            var empQuery = new GetEmployeeSelectListQuery(model.EmployeeId);
            SelectList empSelectList = await Mediator.Send(empQuery);

            var prodQuery = new GetProductsMultiSelectListQuery(id);
            var prodMultiSelectList = await Mediator.Send(prodQuery);

            model.Employees = empSelectList;
            model.Products = prodMultiSelectList;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateContractVm model)
        {
            var empQuery = new GetEmployeeSelectListQuery(model.EmployeeId);
            SelectList empSelectList = await Mediator.Send(empQuery);

            var prodQuery = new GetProductsMultiSelectListQuery(model.ProductsId);
            var prodMultiSelectList = await Mediator.Send(prodQuery);
            model.Employees = empSelectList;
            model.Products = prodMultiSelectList;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new UpdateContractCommand(model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }

            return RedirectToAction("Index", "Restaurants");

        }


        [HttpPost]
        [Route("{id:int:min(1)}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteContractCommand(id);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                return RedirectToAction("Index", "Restaurants");
            }

            return RedirectToAction("Index", "Restaurants");
        }
    }
}
