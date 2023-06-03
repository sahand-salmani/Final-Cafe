using Infrastructure.Common;
using MediatR;

namespace Infrastructure.RestaurantMeetings.Commands
{
    public class DeleteRestaurantMeetingCommand : IRequest<OperationResult<Unit>>
    {
        public DeleteRestaurantMeetingCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
