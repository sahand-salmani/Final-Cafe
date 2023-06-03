using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Interns.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interns.QueryHandlers
{
    public class GetAllInternsQueryHandler : IRequestHandler<GetAllInternsQuery, PaginatedList<Intern>>
    {
        private readonly DatabaseContext _context;

        public GetAllInternsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Intern>> Handle(GetAllInternsQuery request, CancellationToken cancellationToken)
        {
            var interns = _context.Interns.AsNoTracking().OrderByDescending(e => e.CreatedAt);
            return await PaginatedList<Intern>.CreateAsync(interns, request.Page, request.Size);
        }
    }
}
