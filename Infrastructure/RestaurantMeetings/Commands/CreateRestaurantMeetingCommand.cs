using Infrastructure.Common;
using Infrastructure.RestaurantMeetings.ViewModels;
using MediatR;

namespace Infrastructure.RestaurantMeetings.Commands
{
    public class CreateRestaurantMeetingCommand : IRequest<OperationResult<int>>
    {
        public CreateRestaurantMeetingCommand(CreateRestaurantMeetingVm model)
        {
            Model = model;
        }
        public CreateRestaurantMeetingVm Model { get; set; }
    }
}
