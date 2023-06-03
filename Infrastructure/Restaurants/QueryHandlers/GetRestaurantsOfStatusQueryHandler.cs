using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Restaurants.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Restaurants.QueryHandlers
{
    public class GetRestaurantsOfStatusQueryHandler : IRequestHandler<GetRestaurantsOfStatusQuery, PaginatedList<Restaurant>>
    {
        private readonly DatabaseContext _context;

        public GetRestaurantsOfStatusQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Restaurant>> Handle(GetRestaurantsOfStatusQuery request, CancellationToken cancellationToken)
        {
            var restaurants = _context.Restaurants
                .AsNoTracking()
                .Include(c => c.RestaurantContacts)
                .Include(e => e.Contract)
                .ThenInclude(e => e.Employee)
                .Include(e => e.RestaurantStatus)
                .OrderByDescending(e => e.CreatedAt)
                .Where(e => e.RestaurantStatusId == request.StatusId);
            var paginated = await PaginatedList<Restaurant>.CreateAsync(restaurants, request.Page, request.Size);

            return paginated;
        }
    }
}
