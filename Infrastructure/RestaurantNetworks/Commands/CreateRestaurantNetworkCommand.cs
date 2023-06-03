using Infrastructure.Common;
using Infrastructure.RestaurantNetworks.ViewModels;
using MediatR;

namespace Infrastructure.RestaurantNetworks.Commands
{
    public class CreateRestaurantNetworkCommand : IRequest<OperationResult<int>>
    {
        public CreateRestaurantNetworkCommand(CreateRestaurantNetworkVm model)
        {
            Model = model;
        }
        public CreateRestaurantNetworkVm Model { get; set; }
    }
}
