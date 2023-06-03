using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.BlackLists.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.BlackLists.QueryHandlers
{
    public class GetAllBlackListQueryHandler : IRequestHandler<GetAllBlackListQuery, PaginatedList<BlackList>>
    {
        private readonly DatabaseContext _context;

        public GetAllBlackListQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<BlackList>> Handle(GetAllBlackListQuery request, CancellationToken cancellationToken)
        {
            var bl = _context.BlackLists.AsNoTracking().OrderByDescending(b => b.CreatedAt);

            return await PaginatedList<BlackList>.CreateAsync(bl, request.Page, request.Size);
        }
    }
}
