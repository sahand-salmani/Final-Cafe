using Infrastructure.Common;
using Infrastructure.RestaurantMeetings.ViewModels;
using MediatR;

namespace Infrastructure.RestaurantMeetings.Commands
{
    public class UpdateRestaurantMeetingCommand : IRequest<OperationResult<int>>
    {
        public UpdateRestaurantMeetingCommand(UpdateRestaurantMeetingVm model)
        {
            Model = model;
        }
        public UpdateRestaurantMeetingVm Model { get; set; }
    }
}
