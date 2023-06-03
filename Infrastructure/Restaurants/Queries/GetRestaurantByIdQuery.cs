using Infrastructure.Restaurants.ViewModels;
using MediatR;

namespace Infrastructure.Restaurants.Queries
{
    public class GetRestaurantByIdQuery : IRequest<GetRestaurantVm>
    {
        public GetRestaurantByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
