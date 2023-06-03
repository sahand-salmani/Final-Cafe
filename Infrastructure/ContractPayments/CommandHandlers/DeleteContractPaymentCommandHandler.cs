using System.Threading;
using System.Threading.Tasks;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.ContractPayments.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ContractPayments.CommandHandlers
{
    public class DeleteContractPaymentCommandHandler : IRequestHandler<DeleteContractPaymentCommand, OperationResult<Unit>>
    {
        private readonly DatabaseContext _context;
        private readonly IPersistence _persistence;

        public DeleteContractPaymentCommandHandler(DatabaseContext context,
                                                   IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteContractPaymentCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var payment =
                await _context.ContractPayments.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (payment is null)
            {
                return result.AddError("Payment Could not found");
            }


            _context.ContractPayments.Remove(payment);

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
