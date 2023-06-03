using Infrastructure.Common;
using Infrastructure.Identity.ViewModels;
using MediatR;

namespace Infrastructure.Identity.Commands
{
    public class LoginUserCommand : IRequest<OperationResult<string>>
    {
        public LoginUserCommand(LoginVm model)
        {
            Model = model;
        }
        public LoginVm Model { get; set; }
    }
}
