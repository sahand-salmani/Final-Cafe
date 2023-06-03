using Infrastructure.Common;
using Infrastructure.Roles.ViewModels;
using MediatR;

namespace Infrastructure.Roles.Commands
{
    public class AddNewRoleCommand : IRequest<OperationResult<GetRoleVm>>
    {
        public AddNewRoleCommand(AddRoleVm model)
        {
            RoleName = model.RoleName;
        }
        public string RoleName { get; set; }
    }
}
