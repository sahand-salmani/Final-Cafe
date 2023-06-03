using Infrastructure.RestaurantStatuses.ViewModels;
using MediatR;

namespace Infrastructure.Restaurants.Queries
{
    public class GetRestaurantsStatusToUpdateQuery : IRequest<UpdateRestaurantStatusVm>
    {
        public GetRestaurantsStatusToUpdateQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

    }
}
