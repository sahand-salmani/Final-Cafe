using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Infrastructure.Common;
using Infrastructure.Contracts.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contracts.CommandHandlers
{
    public class DeleteContractCommandHandler : IRequestHandler<DeleteContractCommand, OperationResult<Unit>>
    {
        private readonly DatabaseContext _context;

        public DeleteContractCommandHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();
            var contract = await _context.Contracts.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (contract is null)
            {
                return result.AddError("Could not find specified contract");
            }

            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
