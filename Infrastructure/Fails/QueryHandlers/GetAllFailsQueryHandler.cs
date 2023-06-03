using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Fails.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Fails.QueryHandlers
{
    public class GetAllFailsQueryHandler : IRequestHandler<GetAllFailsQuery, PaginatedList<Fail>>
    {
        private readonly DatabaseContext _context;

        public GetAllFailsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Fail>> Handle(GetAllFailsQuery request, CancellationToken cancellationToken)
        {
            var fails = _context.Fails.AsNoTracking().Include(e => e.Employee).OrderByDescending(e => e.CreatedAt);

            return await PaginatedList<Fail>.CreateAsync(fails, request.Page, request.Size);
        }
    }
}
