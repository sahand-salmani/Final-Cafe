using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.Stants.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Stants.CommandHandlers
{
    public class DeleteStantCommandHandler : IRequestHandler<DeleteStantCommand, OperationResult<Unit>>
    {
        private readonly DatabaseContext _context;
        private readonly IPersistence _persistence;

        public DeleteStantCommandHandler(DatabaseContext context,IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteStantCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();
            var stant = await _context.Stants.SingleOrDefaultAsync(s => s.Id == request.Id,cancellationToken);
            if(stant is null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            _context.Stants.Remove(stant);

            var persistence = await _persistence.SaveChangesAsync();

            if(persistence == 0)
            {
                return result.AddError(ErrorMessages.CouldNotDelete);
            }

            result.Entity = Unit.Value;

            return result;
        }
    }
}
