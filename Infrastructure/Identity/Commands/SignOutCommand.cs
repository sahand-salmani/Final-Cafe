using MediatR;

namespace Infrastructure.Identity.Commands
{
    public class SignOutCommand : IRequest<Unit>
    {
    }
}
