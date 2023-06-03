using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.RestaurantStatuses.Queries
{
    public class GetAllRestaurantStatusQuery : IRequest<PaginatedList<RestaurantStatus>>
    {
        public GetAllRestaurantStatusQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
