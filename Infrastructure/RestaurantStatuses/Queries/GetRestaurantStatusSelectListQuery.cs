using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.RestaurantStatuses.Queries
{
    public class GetRestaurantStatusSelectListQuery : IRequest<SelectList>
    {
        public GetRestaurantStatusSelectListQuery(int selected)
        {
            Selected = selected;
        }

        public GetRestaurantStatusSelectListQuery()
        {
            
        }
        public int Selected { get; set; }
    }
}
