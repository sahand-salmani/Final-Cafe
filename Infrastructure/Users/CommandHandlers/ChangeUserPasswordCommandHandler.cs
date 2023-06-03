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
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, OperationResult<string>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ChangeUserPasswordCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<OperationResult<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<string>();

            var user = await _userManager.FindByIdAsync(request.Model.Id);
            if (user is null)
            {
                return result.AddError("istifadəçi tapılmadı");
            }

            IdentityResult identityResult = await _userManager.ChangePasswordAsync(user, request.Model.CurrentPassword, request.Model.NewPassword);

            if (!identityResult.Succeeded)
                return result.AddError(identityResult.Errors.Select(e => e.Description).ToList());


            result.Entity = "Şifrəniz dəyişildi";
            return result;

        }
    }
}
