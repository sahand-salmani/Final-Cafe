using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.Positions.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Positions.CommandHandlers
{
    public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, OperationResult<Unit>>
    {
        private readonly DatabaseContext _context;
        private readonly IPersistence _persistence;

        public DeletePositionCommandHandler(DatabaseContext context,
                                            IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var position = await _context.Positions.Include(e => e.Employees)
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (position.Employees.Any())
            {
                return result.AddError("Could not delete position which has employee associated to it\nRemove employee from that position first!");
            }

            _context.Positions.Remove(position);

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
