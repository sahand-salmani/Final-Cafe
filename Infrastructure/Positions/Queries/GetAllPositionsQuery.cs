using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.Positions.Queries
{
    public class GetAllPositionsQuery : IRequest<PaginatedList<Position>>
    {
        public GetAllPositionsQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
