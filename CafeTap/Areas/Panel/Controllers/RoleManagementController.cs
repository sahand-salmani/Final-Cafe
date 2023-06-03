using System.Collections.Generic;
using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using Infrastructure.Claims.Queries;
using Infrastructure.Common;
using Infrastructure.Roles.Commands;
using Infrastructure.Roles.Queries;
using Infrastructure.Roles.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    [Authorize(Policy = ClaimsList.Users)]
    public class RoleManagementController : MyController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllRolesQuery();
            var model = await Mediator.Send(query);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRoleVm model)
        {
            var command = new AddNewRoleCommand(model);
            var result = await Mediator.Send(command);


            if (result.Success) return RedirectToAction(nameof(Index));


            foreach (var error in result.Errors)
            {
                AddError(error);
            }

            return View(model);

        }


        [HttpGet]
        public async Task<IActionResult> Edit(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                return RedirectToAction(nameof(Index));
            }

            var query = new GetRoleToUpdateQuery(roleName);
            var model = await Mediator.Send(query);
            return model == null ? View("NotFound") : View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateRoleVm model)
        {
            var command = new UpdateRoleCommand(model);
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string name)
        {
            var command = new DeleteRoleCommand(name);
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> AddClaims(string id, string name)
        {
            var model = new RoleClaimsVm();
            var query = new GetAllClaimsMultiSelectListQuery(id);
            var result = await Mediator.Send(query);
            model.Claims = result;
            model.RoleId = id;
            model.RoleName = name;
            model.ClaimsValues = (List<string>)result.SelectedValues;

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddClaims(RoleClaimsVm model)
        {
            var query = new GetAllClaimsMultiSelectListQuery(model.RoleId);
            var multiSelect = await Mediator.Send(query);
            model.Claims = multiSelect;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new UpdateRoleClaimsCommand(model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }


        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> CheckRoleNameExists(string roleName)
        {
            var query = new CheckRoleNameExistsQuery(roleName);
            var result = await Mediator.Send(query);

            return result ? Json($"Role name {roleName} already exists") : Json(true);
        }
    }
}
