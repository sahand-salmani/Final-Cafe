using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Contracts.Queries;
using Infrastructure.RestaurantContacts.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contracts.QueriesHandlers
{
    public class GetRestaurantContractByNameSearchQueryHandler : IRequestHandler<GetRestaurantContractByNameSearchQuery, PaginatedList<Contract>>
    {
        private readonly DatabaseContext _context;

        public GetRestaurantContractByNameSearchQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Contract>> Handle(GetRestaurantContractByNameSearchQuery request, CancellationToken cancellationToken)
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
