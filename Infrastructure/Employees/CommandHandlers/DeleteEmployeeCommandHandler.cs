using System.Threading;
using System.Threading.Tasks;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.Employees.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Employees.CommandHandlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, OperationResult<Unit>>
    {
        private readonly DatabaseContext _context;
        private readonly IPersistence _persistence;

        public DeleteEmployeeCommandHandler(DatabaseContext context,
                                            IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();
            var emp = await _context.Employees.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
            if (emp is null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            _context.Employees.Remove(emp);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.CouldNotDelete);
            }

            result.Entity = Unit.Value;
            return result;
        }
    }
}
