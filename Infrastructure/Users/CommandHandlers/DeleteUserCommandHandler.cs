using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using Infrastructure.Common;
using Infrastructure.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Users.CommandHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, OperationResult<Unit>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var user = await _userManager.FindByIdAsync(request.Id);

            if (user is null)
            {
                return result.AddError("User was not found");
            }

            var identityResult = await _userManager.DeleteAsync(user);

            if (!identityResult.Succeeded)
            {
                return result.AddError(identityResult.Errors.Select(e => e.Description).ToList());
            }

            return result;
        }
    }
}
