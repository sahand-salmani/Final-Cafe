using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.Fails.Queries
{
    public class GetAllFailsQuery : IRequest<PaginatedList<Fail>>
    {
        public GetAllFailsQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
