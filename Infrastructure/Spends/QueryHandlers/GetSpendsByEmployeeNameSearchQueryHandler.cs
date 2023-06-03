using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Spends.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Spends.QueryHandlers
{
    public class GetSpendsByEmployeeNameSearchQueryHandler : IRequestHandler<GetSpendsByEmployeeNameSearchQuery, PaginatedList<Spend>>
    {
        private readonly DatabaseContext _context;

        public GetSpendsByEmployeeNameSearchQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Spend>> Handle(GetSpendsByEmployeeNameSearchQuery request, CancellationToken cancellationToken)
        {
            var spends = _context
                .Spends
                .Where(e => EF.Functions.Like(e.Name, $"%{request.Name}%"))
                .OrderByDescending(e => e.SpentAt);

            return await PaginatedList<Spend>.CreateAsync(spends, request.Page, request.Size);
        }
    }
}
