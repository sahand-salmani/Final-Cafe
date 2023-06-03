using Infrastructure.Common;
using Infrastructure.RestaurantNetworks.ViewModels;
using MediatR;

namespace Infrastructure.RestaurantNetworks.Commands
{
    public class UpdateRestaurantNetworkCommand : IRequest<OperationResult<int>>
    {
        public UpdateRestaurantNetworkCommand(EditRestaurantNetworkVm model)
        {
            Model = model;
        }
        public EditRestaurantNetworkVm Model { get; set; }
    }
}
