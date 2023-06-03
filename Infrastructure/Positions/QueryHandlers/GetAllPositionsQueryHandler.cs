using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Positions.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Positions.QueryHandlers
{
    public class GetAllPositionsQueryHandler : IRequestHandler<GetAllPositionsQuery, PaginatedList<Position>>
    {
        private readonly DatabaseContext _context;

        public GetAllPositionsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Position>> Handle(GetAllPositionsQuery request, CancellationToken cancellationToken)
        {
            var positions = _context.Positions.Include(e => e.Employees).AsNoTracking().OrderByDescending(e => e.CreatedAt);

            return await PaginatedList<Position>.CreateAsync(positions, request.Page, request.Size);
        }
    }
}
