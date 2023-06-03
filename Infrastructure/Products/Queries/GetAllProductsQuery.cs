using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.Products.Queries
{
    public class GetAllProductsQuery : IRequest<PaginatedList<Product>>
    {
        public GetAllProductsQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
