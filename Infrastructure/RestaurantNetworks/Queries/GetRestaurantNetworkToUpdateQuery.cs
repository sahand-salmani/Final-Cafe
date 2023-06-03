using Infrastructure.RestaurantNetworks.ViewModels;
using MediatR;

namespace Infrastructure.RestaurantNetworks.Queries
{
    public class GetRestaurantNetworkToUpdateQuery : IRequest<EditRestaurantNetworkVm>
    {
        public GetRestaurantNetworkToUpdateQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
