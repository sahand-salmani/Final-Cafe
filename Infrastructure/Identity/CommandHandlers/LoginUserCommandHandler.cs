using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using Infrastructure.Common;
using Infrastructure.Identity.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.CommandHandlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, OperationResult<string>>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginUserCommandHandler(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<OperationResult<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<string>();

            var user = await _userManager.FindByNameAsync(request.Model.UserName);

            if (user is null)
            {
                return result.AddError("Invalid Entries");
            }

            var signInResult =
                await _signInManager.PasswordSignInAsync(user, request.Model.Password, true, false);

            if (signInResult.Succeeded)
            {
                result.Entity = user.Id;
                return result;
            }

            if (signInResult.IsLockedOut)
            {
                result.AddError(
                    $"{user.UserName} is locked out. If you think there is a mistake please concat administrator");
            }

            if (signInResult.IsNotAllowed)
            {
                result.AddError($"{user.UserName} is not allowed to login. Please contact administrator");
            }

            return result.AddError("Username of password are not correct");
        }
    }
}
