using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Restaurants.Queries
{
    public class GetRestaurantsSelectListQuery : IRequest<SelectList>
    {
        public GetRestaurantsSelectListQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
