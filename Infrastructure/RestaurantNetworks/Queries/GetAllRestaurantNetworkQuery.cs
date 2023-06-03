using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.RestaurantNetworks.Queries
{
    public class GetAllRestaurantNetworkQuery : IRequest<PaginatedList<RestaurantNetwork>>
    {
        public GetAllRestaurantNetworkQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
