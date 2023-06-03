using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Restaurants.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Restaurants.QueryHandlers
{
    public class GetRestaurantsSelectListQueryHandler : IRequestHandler<GetRestaurantsSelectListQuery, SelectList>
    {
        private readonly DatabaseContext _context;

        public GetRestaurantsSelectListQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<SelectList> Handle(GetRestaurantsSelectListQuery request, CancellationToken cancellationToken)
        {
            var restaurants = await _context.Restaurants.ToListAsync(cancellationToken);

            if (request.Id == 0)
            {
                return new SelectList(restaurants, nameof(Restaurant.Id), nameof(Restaurant.Name));
            }

            return new SelectList(restaurants, nameof(Restaurant.Id), nameof(Restaurant.Name), request.Id);
        }
    }
}
