using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Contracts.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contracts.QueriesHandlers
{
    public class GetContractsOfProductQueryHandler : IRequestHandler<GetContractsOfProductQuery, PaginatedList<Contract>>
    {
        private readonly DatabaseContext _context;

        public GetContractsOfProductQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Contract>> Handle(GetContractsOfProductQuery request, CancellationToken cancellationToken)
        {
            var contracts = _context.Contracts
                .Include(e => e.Employee)
                .Include(e => e.Restaurant)
                .AsNoTracking()
                .Where(e => e.ContractProducts.Any(e => e.ProductId == request.ProductId))
                .OrderByDescending(e => e.EndDate);

            return await PaginatedList<Contract>.CreateAsync(contracts, request.Page, request.Size);
        }
    }
}
