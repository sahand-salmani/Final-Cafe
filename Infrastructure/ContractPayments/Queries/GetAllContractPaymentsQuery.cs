using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.ContractPayments.Queries
{
    public class GetAllContractPaymentsQuery : IRequest<PaginatedList<ContractPayment>>
    {
        public GetAllContractPaymentsQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }

    }
}
