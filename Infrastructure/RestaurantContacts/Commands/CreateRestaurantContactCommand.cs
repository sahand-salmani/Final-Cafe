using Infrastructure.Common;
using Infrastructure.RestaurantContacts.ViewModels;
using MediatR;

namespace Infrastructure.RestaurantContacts.Commands
{
    public class CreateRestaurantContactCommand : IRequest<OperationResult<int>>
    {
        public CreateRestaurantContactCommand(CreateRestaurantContactDetailVm model)
        {
            Model = model;
        }
        public CreateRestaurantContactDetailVm Model { get; set; }     
    }
}
