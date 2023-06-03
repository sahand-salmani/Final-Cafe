using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using Infrastructure.Identity.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.CommandHandlers
{
    public class SignOutCommandHandler : IRequestHandler<SignOutCommand, Unit>
    {
        private readonly SignInManager<ApplicationUser> _signManager;

        public SignOutCommandHandler(SignInManager<ApplicationUser> signManager)
        {
            _signManager = signManager;
        }
        public async Task<Unit> Handle(SignOutCommand request, CancellationToken cancellationToken)
        {
            await _signManager.SignOutAsync();
            return Unit.Value;
        }
    }
}
