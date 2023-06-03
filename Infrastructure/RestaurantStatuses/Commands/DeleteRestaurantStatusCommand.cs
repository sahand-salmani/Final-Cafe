using Infrastructure.Common;
using MediatR;

namespace Infrastructure.RestaurantStatuses.Commands
{
    public class DeleteRestaurantStatusCommand : IRequest<OperationResult<Unit>>
    {
        public DeleteRestaurantStatusCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
