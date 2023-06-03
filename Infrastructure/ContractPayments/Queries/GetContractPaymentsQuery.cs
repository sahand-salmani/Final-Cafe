using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.ContractPayments.Queries
{
    public class GetContractPaymentsQuery : IRequest<PaginatedList<ContractPayment>>
    {
        public GetContractPaymentsQuery(int id, int page, int size)
        {
            Id = id;
            Page = page;
            Size = size;
        }
        public int Id { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
