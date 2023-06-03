using Infrastructure.Common;
using MediatR;

namespace Infrastructure.Restaurants.Commands
{
    public class DeleteRestaurantCommand : IRequest<OperationResult<Unit>>
    {
        public int Id { get; set; }

        public DeleteRestaurantCommand(int id)
        {
            Id = id;
        }
    }
}
