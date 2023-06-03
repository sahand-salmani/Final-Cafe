using System.Threading;
using System.Threading.Tasks;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.Fails.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Fails.CommandHandlers
{
    public class DeleteFailCommandHandler : IRequestHandler<DeleteFailCommand,OperationResult<Unit>>
    {
        private readonly DatabaseContext _context;
        private readonly IPersistence _persistence;

        public DeleteFailCommandHandler(DatabaseContext context,
                                        IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteFailCommand request, CancellationToken cancellationToken)
        {

            var result = new OperationResult<Unit>();

            var fail = await _context.Fails.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);


            if (fail is null)
            {
                return result.AddError("Fail was not found");
            }


            _context.Fails.Remove(fail);

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
