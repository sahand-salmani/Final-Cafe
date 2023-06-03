using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.EmployeePayments.Queries
{
    public class GetAllEmployeePaymentsQuery :IRequest<PaginatedList<EmployeePayment>>
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public GetAllEmployeePaymentsQuery(int page,int size)
        {
            Page = page;
            Size = size;
        }
    }
}
