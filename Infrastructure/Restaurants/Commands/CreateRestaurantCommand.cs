using Infrastructure.Common;
using Infrastructure.Restaurants.ViewModels;
using MediatR;

namespace Infrastructure.Restaurants.Commands
{
    public class CreateRestaurantCommand : IRequest<OperationResult<int>>
    {
        public CreateRestaurantCommand(CreateRestaurantInDetailsVm model)
        {
            Model = model;
        }
        public CreateRestaurantInDetailsVm Model { get; set; }

    }
}
