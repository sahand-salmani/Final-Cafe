using Infrastructure.Common;
using MediatR;

namespace Infrastructure.EmployeeFaults.Commands
{
    public class DeleteEmployeeFaultCommand : IRequest<OperationResult<int>>
    {
        public DeleteEmployeeFaultCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
