using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class GetInternBySearchNameQueryHandler : IRequestHandler<GetInternBySearchNameQuery, PaginatedList<Intern>>
    {
        private readonly DatabaseContext _context;

        public GetInternBySearchNameQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Intern>> Handle(GetInternBySearchNameQuery request, CancellationToken cancellationToken)
        {
            var interns = _context.Interns
                .AsNoTracking()
                .Where(e => EF.Functions.Like(e.Name, $"%{request.Name}%"))
                .OrderByDescending(e => e.CreatedAt);
            return await PaginatedList<Intern>.CreateAsync(interns, request.Page, request.Size);
        }
    }
}
