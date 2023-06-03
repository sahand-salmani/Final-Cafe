using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.Employees.Queries
{
    public class GetAllEmployeesQuery : IRequest<PaginatedList<Employee>>
    {
        public GetAllEmployeesQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
