using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Restaurants.Queries;
using Infrastructure.RestaurantStatuses.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Restaurants.QueryHandlers
{
    public class GetRestaurantsStatusToUpdateQueryHandler : IRequestHandler<GetRestaurantsStatusToUpdateQuery, UpdateRestaurantStatusVm>
    {
        private readonly DatabaseContext _context;

        public GetRestaurantsStatusToUpdateQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<UpdateRestaurantStatusVm> Handle(GetRestaurantsStatusToUpdateQuery request, CancellationToken cancellationToken)
        {
            var model = new UpdateRestaurantStatusVm();

            var restaurant = await _context.Restaurants.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            var statuses = await _context.RestaurantStatus.ToListAsync(cancellationToken);

            model.Id = restaurant.Id;
            model.StatusId = restaurant.RestaurantStatusId;
            model.Status = new SelectList(statuses, nameof(RestaurantStatus.Id), nameof(RestaurantStatus.Name),
                restaurant.RestaurantStatusId);

            return model;
        }
    }
}
