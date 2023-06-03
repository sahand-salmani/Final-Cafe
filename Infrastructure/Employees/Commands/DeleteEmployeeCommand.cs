using Infrastructure.Common;
using MediatR;

namespace Infrastructure.Employees.Commands
{
    public class DeleteEmployeeCommand : IRequest<OperationResult<Unit>>
    {
        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
