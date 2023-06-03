using Infrastructure.Common;
using Infrastructure.Restaurants.ViewModels;
using MediatR;

namespace Infrastructure.Restaurants.Commands
{
    public class UpdateRestaurantCommand : IRequest<OperationResult<int>>
    {
        public UpdateRestaurantCommand(int id, UpdateRestaurantVm model)
        {
            Id = id;
            Model = model;
        }
        public int Id { get; set; }
        public UpdateRestaurantVm Model { get; set; }
    }
}
