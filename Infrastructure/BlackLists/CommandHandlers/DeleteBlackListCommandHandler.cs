using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Infrastructure.BlackLists.Commands;
using Infrastructure.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.BlackLists.CommandHandlers
{
    public class DeleteBlackListCommandHandler : IRequestHandler<DeleteBlackListCommand, OperationResult<Unit>>
    {
        private readonly DatabaseContext _context;

        public DeleteBlackListCommandHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteBlackListCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();
            var bl = await _context.BlackLists.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (bl is null)
            {
                return result.AddError("Black list was not found");
            }

            _context.BlackLists.Remove(bl);
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
