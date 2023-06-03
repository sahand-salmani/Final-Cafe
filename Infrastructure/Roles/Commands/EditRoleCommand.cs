using Infrastructure.Common;
using Infrastructure.Roles.ViewModels;
using MediatR;

namespace Infrastructure.Roles.Commands
{
    public class EditRoleCommand : IRequest<OperationResult<GetRoleVm>>
    {
        public EditRoleCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
