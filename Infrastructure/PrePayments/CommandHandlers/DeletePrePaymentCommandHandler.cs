using System.Threading;
using System.Threading.Tasks;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.PrePayments.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.PrePayments.CommandHandlers
{
    public class DeletePrePaymentCommandHandler : IRequestHandler<DeletePrePaymentCommand, OperationResult<Unit>>
    {
        private readonly DatabaseContext _context;
        private readonly IPersistence _persistence;

        public DeletePrePaymentCommandHandler(DatabaseContext context,
                                              IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeletePrePaymentCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var prePayment =
                await _context.PrePayments.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (prePayment is null)
            {
                return result.AddError("Pre Payment was not found");
            }

            _context.PrePayments.Remove(prePayment);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.CouldNotDelete);
            }

            return result;
        }
    }
}
