using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.EmployeePunishments.Queries
{
    public class GetPunishmentsOfEmployeeQuery : IRequest<PaginatedList<EmployeePunishment>>
    {
        public GetPunishmentsOfEmployeeQuery(int id, int page, int size)
        {
            Id = id;
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
        public int Id { get; set; }
    }
}
