using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.EmployeePayments.Queries
{
    public class GetPaymentsOfEmployeeQuery : IRequest<PaginatedList<EmployeePayment>>
    {
        public GetPaymentsOfEmployeeQuery(int id, int page, int size)
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
