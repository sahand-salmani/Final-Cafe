using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.Employees.Queries
{
    public class GetEmployeesBySearchNameQuery : IRequest<PaginatedList<Employee>>
    {
        public GetEmployeesBySearchNameQuery(int page, int size, string name)
        {
            Page = page;
            Size = size;
            Name = name;
        }
        public int Page { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
    }
}
