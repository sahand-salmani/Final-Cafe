using Infrastructure.Common;
using Infrastructure.UserToken.ViewModels;
using MediatR;

namespace Infrastructure.UserToken.Commands
{
    public class CreateUserTokenCommand : IRequest<OperationResult<int>>
    {
        public CreateUserTokenCommand(CreateUserTokenVm model)
        {
            Model = model;
        }
        public CreateUserTokenVm Model { get; set; }
    }
}
