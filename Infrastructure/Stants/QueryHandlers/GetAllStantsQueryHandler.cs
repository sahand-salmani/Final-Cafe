using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Stants.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Stants.QueryHandlers
{
    public class GetAllStantsQueryHandler : IRequestHandler<GetAllStantsQuery, PaginatedList<Stant>>
    {
        private readonly DatabaseContext _context;

        public GetAllStantsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Stant>> Handle(GetAllStantsQuery request, CancellationToken cancellationToken)
        {
            var stants = _context.Stants.Include(r => r.Restaurant).AsNoTracking().OrderByDescending(s => s.CreatedAt);
            return await PaginatedList<Stant>.CreateAsync(stants, request.Page, request.Size);
        }
    }
}
