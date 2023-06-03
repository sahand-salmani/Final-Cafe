using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.RestaurantNetworks.Queries
{
    public class GetAllRestaurantsOfNetworkQuery : IRequest<PaginatedList<Restaurant>>
    {
        public int Id { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }

        public GetAllRestaurantsOfNetworkQuery(int id, int page, int size)
        {
            Id = id;
            Page = page;
            Size = size;
        }
    }
}
