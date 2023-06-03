using Infrastructure.Common;
using MediatR;

namespace Infrastructure.Roles.Commands
{
    public class DeleteRoleCommand : IRequest<OperationResult<Unit>>
    {
        public DeleteRoleCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
