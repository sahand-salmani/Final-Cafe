using Infrastructure.Common;
using MediatR;

namespace Infrastructure.RestaurantContacts.Commands
{
    public class DeleteRestaurantContractQuery : IRequest<OperationResult<int>>
    {
        public DeleteRestaurantContractQuery(int id, int restaurantId)
        {
            Id = id;
            RestaurantId = restaurantId;
        }
        public int Id { get; set; }
        public int RestaurantId { get; set; }
    }
}
