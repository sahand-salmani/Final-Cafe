using Infrastructure.Common;
using MediatR;

namespace Infrastructure.RestaurantNetworks.Commands
{
    public class DeleteRestaurantNetworkCommand : IRequest<OperationResult<Unit>>
    {
        public DeleteRestaurantNetworkCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
