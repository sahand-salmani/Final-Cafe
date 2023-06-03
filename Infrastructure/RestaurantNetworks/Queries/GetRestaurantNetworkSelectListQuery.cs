using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.RestaurantNetworks.Queries
{
    public class GetRestaurantNetworkSelectListQuery : IRequest<SelectList>
    {
        public GetRestaurantNetworkSelectListQuery()
        {
            
        }

        public GetRestaurantNetworkSelectListQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
