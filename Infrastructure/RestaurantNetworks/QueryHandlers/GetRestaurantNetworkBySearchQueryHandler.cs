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
    public class GetRestaurantNetworkBySearchQueryHandler : IRequestHandler<GetRestaurantNetworkBySearchQuery, PaginatedList<RestaurantNetwork>>
    {
        private readonly DatabaseContext _context;

        public GetRestaurantNetworkBySearchQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<RestaurantNetwork>> Handle(GetRestaurantNetworkBySearchQuery request, CancellationToken cancellationToken)
        {
            var networks = _context.RestaurantNetworks
                .Include(e => e.Restaurants)
                .Where(e => EF.Functions.Like(e.Name, $"%{request.Name}%"))
                .AsNoTracking()
                .OrderByDescending(e => e.CreatedAt);

            return await PaginatedList<RestaurantNetwork>.CreateAsync(networks, request.Page, request.Size);
        }
    }
}
