using Infrastructure.RestaurantStatuses.ViewModels;
using MediatR;

namespace Infrastructure.RestaurantStatuses.Queries
{
    public class GetRestaurantStatusToUpdateQuery : IRequest<EditRestaurantStatusVm>
    {
        public GetRestaurantStatusToUpdateQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
