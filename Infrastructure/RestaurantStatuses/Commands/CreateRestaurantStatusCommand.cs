using Infrastructure.Common;
using Infrastructure.RestaurantStatuses.ViewModels;
using MediatR;

namespace Infrastructure.RestaurantStatuses.Commands
{
    public class CreateRestaurantStatusCommand : IRequest<OperationResult<int>>
    {
        public CreateRestaurantStatusCommand(CreateRestaurantStatusVm model)
        {
            Model = model;
        }
        public CreateRestaurantStatusVm Model { get; set; }
    }
}
