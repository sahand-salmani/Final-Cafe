using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Infrastructure.Common;
using Infrastructure.RestaurantStatuses.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantStatuses.QueryHandler
{
    public class GetRestaurantToUpdateStatusQueryHandler : IRequestHandler<GetRestaurantToUpdateStatusQuery, OperationResult<int>>
    {
        private readonly DatabaseContext _context;

        public GetRestaurantToUpdateStatusQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<OperationResult<int>> Handle(GetRestaurantToUpdateStatusQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var status =
                await _context.RestaurantStatus.SingleOrDefaultAsync(e => e.Id == request.Model.StatusId, cancellationToken);

            if (status is null)
            {
                return result.AddError("Status was not found");
            }

            var restaurant = await _context.Restaurants.FindAsync(request.Model.Id);
            restaurant.RestaurantStatusId = status.Id;
            
            
            _context.Restaurants.Update(restaurant);

            await _context.SaveChangesAsync(cancellationToken);

            result.Entity = restaurant.Id;
            return result;
        }
    }
}
