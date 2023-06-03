using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.RestaurantNetworks.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantNetworks.QueryHandlers
{
    public class GetAllRestaurantNetworkQueryHandler : IRequestHandler<GetAllRestaurantNetworkQuery, PaginatedList<RestaurantNetwork>>
    {
        private readonly DatabaseContext _context;

        public GetAllRestaurantNetworkQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<RestaurantNetwork>> Handle(GetAllRestaurantNetworkQuery request, CancellationToken cancellationToken)
        {
            var rn = _context.RestaurantNetworks.Include(e => e.Restaurants).AsNoTracking().Include(e => e.Restaurants)
                .OrderByDescending(e => e.CreatedAt);

            return await PaginatedList<RestaurantNetwork>.CreateAsync(rn, request.Page, request.Size);
        }
    }
}
