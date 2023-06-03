using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.BlackLists.Queries
{
    public class GetAllBlackListQuery : IRequest<PaginatedList<BlackList>>
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public GetAllBlackListQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
    }
}
