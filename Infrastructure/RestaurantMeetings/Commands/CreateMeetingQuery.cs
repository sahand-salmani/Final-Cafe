using Infrastructure.Common;
using Infrastructure.RestaurantMeetings.ViewModels;
using MediatR;

namespace Infrastructure.RestaurantMeetings.Commands
{
    public class CreateMeetingQuery : IRequest<OperationResult<int>>
    {
        public CreateMeetingQuery(CreateMeetingVm model)
        {
            Model = model;
        }
        public CreateMeetingVm Model { get; set; }
    }
}
