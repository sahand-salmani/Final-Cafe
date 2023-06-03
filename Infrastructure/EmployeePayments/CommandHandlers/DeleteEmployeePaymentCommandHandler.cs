using System.Threading;
using System.Threading.Tasks;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.EmployeePayments.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EmployeePayments.CommandHandlers
{
    public class DeleteEmployeePaymentCommandHandler : IRequestHandler<DeleteEmployeePaymentCommand, OperationResult<Unit>>
    {
        private readonly DatabaseContext _context;
        private readonly IPersistence _persistence;

        public DeleteEmployeePaymentCommandHandler(DatabaseContext context, IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteEmployeePaymentCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var employeePayment =
                await _context.EmployeePayments.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);


            if (employeePayment is null)
            {
                return result.AddError("Payment was not found");
            }

            _context.EmployeePayments.Remove(employeePayment);


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
