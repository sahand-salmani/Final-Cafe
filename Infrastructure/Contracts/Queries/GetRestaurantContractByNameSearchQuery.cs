using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.Contracts.Queries
{
    public class GetRestaurantContractByNameSearchQuery : IRequest<PaginatedList<Contract>>
    {
        public GetRestaurantContractByNameSearchQuery(string name, int page, int size)
        {
            Name = name;
            Page = page;
            Size = size;
        }
        public string Name { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
