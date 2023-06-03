using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.Stants.Queries
{
    public class GetAllStantsQuery : IRequest<PaginatedList<Stant>>
    {
        public GetAllStantsQuery(int page,int size)
        {
            Page = page;
            Size = size;
        }
        public int Size { get; set; }
        public int Page { get; set; }
    }
}
