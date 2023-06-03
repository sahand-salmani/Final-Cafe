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
    public class GetAllRestaurantsOfNetworkQueryHandler : IRequestHandler<GetAllRestaurantsOfNetworkQuery, PaginatedList<Restaurant>>
    {
        private readonly DatabaseContext _context;

        public GetAllRestaurantsOfNetworkQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Restaurant>> Handle(GetAllRestaurantsOfNetworkQuery request, CancellationToken cancellationToken)
        {
            var restaurants = _context.Restaurants
                .AsNoTracking()
                .Include(c => c.RestaurantContacts)
                .Include(e => e.Contract)
                .ThenInclude(e => e.Employee)
                .Include(e => e.RestaurantStatus)
                .Where(e => e.RestaurantNetworkId.Value == request.Id)
                .OrderByDescending(e => e.CreatedAt);
            return await PaginatedList<Restaurant>.CreateAsync(restaurants, request.Page, request.Size);
        }
    }
}
