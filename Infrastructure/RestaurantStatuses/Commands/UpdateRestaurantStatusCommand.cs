using Infrastructure.Common;
using Infrastructure.RestaurantStatuses.ViewModels;
using MediatR;

namespace Infrastructure.RestaurantStatuses.Commands
{
    public class UpdateRestaurantStatusCommand : IRequest<OperationResult<int>>
    {
        public UpdateRestaurantStatusCommand(EditRestaurantStatusVm model)
        {
            Model = model;
        }
        public EditRestaurantStatusVm Model { get; set; }
    }
}
