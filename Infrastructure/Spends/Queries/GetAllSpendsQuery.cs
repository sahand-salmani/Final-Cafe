using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.Spends.Queries
{
    public class GetAllSpendsQuery : IRequest<PaginatedList<Spend>>
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public GetAllSpendsQuery(int page,int size)
        {
            Page = page;
            Size = size;
        }
    }
}
