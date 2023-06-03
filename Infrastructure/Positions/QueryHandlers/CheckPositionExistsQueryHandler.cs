using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Infrastructure.Positions.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Positions.QueryHandlers
{
    public class CheckPositionExistsQueryHandler : IRequestHandler<CheckPositionExistsQuery, bool>
    {
        private readonly DatabaseContext _context;

        public CheckPositionExistsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CheckPositionExistsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Positions.AsNoTracking().AnyAsync(e => e.Name == request.Name, cancellationToken);
        }
    }
}
