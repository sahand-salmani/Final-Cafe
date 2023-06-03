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
    public class GetAllRestaurantSearchByNameQueryHandler : IRequestHandler<GetAllRestaurantSearchByNameQuery, PaginatedList<Restaurant>>
    {
        private readonly DatabaseContext _context;

        public GetAllRestaurantSearchByNameQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Restaurant>> Handle(GetAllRestaurantSearchByNameQuery request, CancellationToken cancellationToken)
        {
            var restaurants = _context.Restaurants
                .AsNoTracking()
                .Include(c => c.RestaurantContacts)
                .Include(e => e.Contract)
                .ThenInclude(e => e.Employee)
                .Where(e => EF.Functions.Like(e.Name, $"{request.Name}%"))
                .OrderByDescending(e => e.CreatedAt);


            return await PaginatedList<Restaurant>.CreateAsync(restaurants, request.Page, request.Size);
        }
    }
}
