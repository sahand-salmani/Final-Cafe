using Infrastructure.Common;
using Infrastructure.Users.ViewModels;
using MediatR;

namespace Infrastructure.Users.Commands
{
    public class CreateUserWithTokenCommand : IRequest<OperationResult<string>>
    {
        public CreateUserWithTokenCommand(AddNewUserVm model)
        {
            Model = model;
        }
        public AddNewUserVm Model { get; set; }
    }
}
