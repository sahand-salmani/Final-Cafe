using System.Linq;
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
    public class GetContractsOfCityBySearchQueryHandler : IRequestHandler<GetContractsOfCityBySearchQuery, PaginatedList<Contract>>
    {
        private readonly DatabaseContext _context;

        public GetContractsOfCityBySearchQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Contract>> Handle(GetContractsOfCityBySearchQuery request, CancellationToken cancellationToken)
        {
            var contracts = _context.Contracts
                .Include(e => e.Restaurant)
                .Include(e => e.Employee)
                .AsNoTracking()
                .Where(e => EF.Functions.Like(e.Restaurant.City.ToUpper(), $"%{request.Name.ToUpper()}%"))
                .OrderByDescending(e => e.CreatedAt);

            return await PaginatedList<Contract>.CreateAsync(contracts, request.Page, request.Size);
        }
    }
}
