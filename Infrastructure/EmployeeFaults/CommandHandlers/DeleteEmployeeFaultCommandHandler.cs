using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Infrastructure.Common;
using Infrastructure.EmployeeFaults.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EmployeeFaults.CommandHandlers
{
    public class DeleteEmployeeFaultCommandHandler : IRequestHandler<DeleteEmployeeFaultCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;

        public DeleteEmployeeFaultCommandHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<OperationResult<int>> Handle(DeleteEmployeeFaultCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var fault = await _context.EmployeeFaults.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);


            if (fault is null)
            {
                return result.AddError("Fault was not found");
            }

            var userId = fault.EmployeeId;

            _context.EmployeeFaults.Remove(fault);

            await _context.SaveChangesAsync(cancellationToken);

            result.Entity = userId;

            return result;

        }
    }
}
