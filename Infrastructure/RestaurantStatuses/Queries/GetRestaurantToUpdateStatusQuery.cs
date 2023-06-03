using Infrastructure.Common;
using Infrastructure.RestaurantStatuses.ViewModels;
using MediatR;

namespace Infrastructure.RestaurantStatuses.Queries
{
    public class GetRestaurantToUpdateStatusQuery : IRequest<OperationResult<int>>
    {
        public GetRestaurantToUpdateStatusQuery(UpdateRestaurantStatusVm model)
        {
            Model = model;
        }
        public UpdateRestaurantStatusVm Model { get; set; }
    }
}
