using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Employees.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Employees.QueryHandlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, PaginatedList<Employee>>
    {
        private readonly DatabaseContext _context;

        public GetAllEmployeesQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = _context.Employees.Include(e => e.Position).AsNoTracking().OrderByDescending(e => e.CreatedAt);
            return await PaginatedList<Employee>.CreateAsync(employees, request.Page, request.Size);
        }
    }
}
