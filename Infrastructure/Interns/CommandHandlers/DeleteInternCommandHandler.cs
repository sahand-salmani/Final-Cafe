using System.Threading;
using System.Threading.Tasks;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.Interns.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interns.CommandHandlers
{
    public class DeleteInternCommandHandler : IRequestHandler<DeleteInternCommand,OperationResult<Unit>>
    {
        private readonly DatabaseContext _context;
        private readonly IPersistence _persistence;

        public DeleteInternCommandHandler(DatabaseContext context,
                                          IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteInternCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var intern = await _context.Interns.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (intern is null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            _context.Interns.Remove(intern);
            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.CouldNotDelete);
            }

            return result;
        }
    }
}
