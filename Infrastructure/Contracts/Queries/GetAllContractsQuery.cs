using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.Contracts.Queries
{
    public class GetAllContractsQuery : IRequest<PaginatedList<Contract>>
    {
        public GetAllContractsQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
