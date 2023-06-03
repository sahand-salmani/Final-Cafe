using Infrastructure.Common;
using MediatR;

namespace Infrastructure.EmployeePunishments.Commands
{
    public class DeleteEmployeePunishmentCommand : IRequest<OperationResult<int>>
    {
        public DeleteEmployeePunishmentCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
