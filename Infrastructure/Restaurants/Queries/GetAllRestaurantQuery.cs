using DataAccess.Pagination;
using MediatR;
using Domain.Models;

namespace Infrastructure.Restaurants.Queries
{
    public class GetAllRestaurantQuery : IRequest<PaginatedList<Restaurant>>
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public GetAllRestaurantQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
    }
}
