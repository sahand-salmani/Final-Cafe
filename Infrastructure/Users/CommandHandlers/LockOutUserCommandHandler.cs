using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using Infrastructure.Common;
using Infrastructure.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Users.CommandHandlers
{
    public class LockOutUserCommandHandler : IRequestHandler<LockOutUserCommand, OperationResult<Unit>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public LockOutUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<OperationResult<Unit>> Handle(LockOutUserCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user is null)
            {
                return result.AddError("User Was not found");
            }

            if (user.UserName.ToUpper() == "ADMIN")
            {
                return result.AddError("Admin can not be locked out");
            }

            var identityResult = await _userManager.SetLockoutEnabledAsync(user, true);
            if (!identityResult.Succeeded)
            {
                return result.AddError(identityResult.Errors.Select(e => e.Description).ToList());
            }


            return result;
        }
    }
}
