using Infrastructure.Common;
using Infrastructure.Users.ViewModels;
using MediatR;

namespace Infrastructure.Users.Commands
{
    public class EditUserRoleCommand : IRequest<OperationResult<string>>
    {
        public EditUserRoleCommand(EditUserRoleVm model)
        {
            Model = model;
        }
        public EditUserRoleVm Model { get; set; }
    }
}
