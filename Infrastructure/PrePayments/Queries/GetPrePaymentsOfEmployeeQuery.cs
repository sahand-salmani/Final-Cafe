using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.PrePayments.Queries
{
    public class GetPrePaymentsOfEmployeeQuery : IRequest<PaginatedList<PrePayment>>
    {
        public GetPrePaymentsOfEmployeeQuery(int id, int page, int size)
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
