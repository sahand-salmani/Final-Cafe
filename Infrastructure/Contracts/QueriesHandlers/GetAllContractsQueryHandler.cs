using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Contracts.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contracts.QueriesHandlers
{
    public class GetAllContractsQueryHandler : IRequestHandler<GetAllContractsQuery, PaginatedList<Contract>>
    {
        private readonly DatabaseContext _context;

        public GetAllContractsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Contract>> Handle(GetAllContractsQuery request, CancellationToken cancellationToken)
        {
            var now = DateTime.Now.ToAzDateTime();
            var contracts = _context.Contracts.Include(e => e.Employee).Include(e => e.Restaurant)
                .AsNoTracking()
                .Where(e => e.EndDate > now)
                .OrderBy(e => e.EndDate);

            return await PaginatedList<Contract>.CreateAsync(contracts, request.Page, request.Size);
        }
    }
}
