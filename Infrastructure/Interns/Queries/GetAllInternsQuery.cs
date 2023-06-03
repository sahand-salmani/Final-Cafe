using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.Interns.Queries
{
    public class GetAllInternsQuery : IRequest<PaginatedList<Intern>>
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public GetAllInternsQuery(int page, int size)
        {
            Page = page;
            Size = size;
            if (page == 0)
            {
                Page = 1;
            }
        }
    }
}
