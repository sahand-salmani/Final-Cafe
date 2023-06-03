using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Stants.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Stants.QueryHandlers
{
    public class GetStantsByNameSearchQueryHandler : IRequestHandler<GetStantsByNameSearchQuery, PaginatedList<Stant>>
    {
        private readonly DatabaseContext _context;

        public GetStantsByNameSearchQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Stant>> Handle(GetStantsByNameSearchQuery request, CancellationToken cancellationToken)
        {
            var stants = _context.Stants
                .Include(e => e.Restaurant)
                .AsNoTracking()
                .Where(e => EF.Functions.Like(e.Restaurant.Name, $"%{request.Name}%"))
                .OrderByDescending(e => e.CreatedAt);

            return await PaginatedList<Stant>.CreateAsync(stants, request.Page, request.Size);
        }
    }
}
