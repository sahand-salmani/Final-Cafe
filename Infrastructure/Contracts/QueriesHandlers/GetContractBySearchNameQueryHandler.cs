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
    public class GetContractBySearchNameQueryHandler : IRequestHandler<GetContractBySearchNameQuery, PaginatedList<Contract>>
    {
        private readonly DatabaseContext _context;

        public GetContractBySearchNameQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Contract>> Handle(GetContractBySearchNameQuery request, CancellationToken cancellationToken)
        {
            var contracts = _context.Contracts
                .Include(e => e.Employee)
                .Include(e => e.Restaurant)
                .AsNoTracking()
                .Where(e => EF.Functions.Like(e.Name, $"%{request.Name}%"))
                .OrderByDescending(e => e.EndDate);

            return await PaginatedList<Contract>.CreateAsync(contracts, request.Page, request.Size);
        }
    }
}
