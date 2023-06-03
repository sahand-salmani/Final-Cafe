using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using Infrastructure.Common;
using Infrastructure.Roles.Queries;
using Infrastructure.Users.Commands;
using Infrastructure.Users.Queries;
using Infrastructure.Users.ViewModels;
using Infrastructure.UserToken.Commands;
using Infrastructure.UserToken.Queries;
using Infrastructure.UserToken.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    [Authorize(Policy = ClaimsList.Users)]
    public class UserManagementController : MyController
    {

        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllUsersQuery(page, 10);
            var result = await Mediator.Send(query);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> EditUserRole(string id)
        {
            var query = new GetUserToUpdateQuery(id);
            EditUserRoleVm model = await Mediator.Send(query);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditUserRole(EditUserRoleVm model)
        {
            var userRoleQuery = new GetUserRolesQuery(model.Id);
            var selectList = await Mediator.Send(userRoleQuery);
            model.SelectList = selectList;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var command = new EditUserRoleCommand(model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new DeleteUserCommand(id);
            var result = await Mediator.Send(command);

            if (result.Success)
            {
                AddError(result.Errors);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> CreateTokenForRegistration()
        {
            var model = new CreateUserTokenVm();
            var query = new GetRoleSelectListQuery();
            model.Roles = await Mediator.Send(query);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenForRegistration(CreateUserTokenVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var command = new CreateUserTokenCommand(model);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                AddError(result.Errors);
                return View(model);
            }

            SuccessMessage("Token Created");
            return RedirectToAction(nameof(AllTokens));
        }


        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> AllTokens(int page = 1)
        {
            var query = new GetAllTokensQuery(page, 20);
            return View(await Mediator.Send(query));
        }


        [HttpPost]
        public async Task<IActionResult> DeleteToken(int id)
        {
            var command = new DeleteTokenCommand(id);
            var result = await Mediator.Send(command);

            if (!result.Success)
            {
                FailMessages(result.Errors);
                return RedirectToAction(nameof(AllTokens));
            }


            SuccessMessage("Token Deleted");
            return RedirectToAction(nameof(AllTokens));
        }



        [AcceptVerbs("get", "post")]
        public async Task<IActionResult> CheckTokenExists(string token)
        {
            var query = new CheckTokenExistsQuery(token);
            var result = await Mediator.Send(query);
            return result ? Json($"Token {token} already exists") : Json(true);
        }

    }
}
