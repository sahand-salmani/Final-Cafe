using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Employees.QueryHandlers
{
    public class GetEmployeeSelectListQueryHandler : IRequestHandler<GetEmployeeSelectListQuery, SelectList>
    {
        private readonly DatabaseContext _context;

        public GetEmployeeSelectListQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<SelectList> Handle(GetEmployeeSelectListQuery request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees.Where(e => e.CanMakeContract).AsNoTracking().OrderBy(e => e.FullName).ToListAsync(cancellationToken);

            return new SelectList(employees, nameof(Employee.Id), nameof(Employee.FullName), request.Id);
        }
    }
}
