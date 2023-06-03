using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.EmployeeFaults.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EmployeeFaults.QueryHandlers
{
    public class GetEmployeeFaultBySearchQueryHandler: IRequestHandler<GetEmployeeFaultBySearchQuery, PaginatedList<EmployeeFault>>
    {
        private readonly DatabaseContext _context;

        public GetEmployeeFaultBySearchQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<EmployeeFault>> Handle(GetEmployeeFaultBySearchQuery request, CancellationToken cancellationToken)
        {
            var query = _context.EmployeeFaults.Include(e => e.Employee)
                .Where(e => EF.Functions.Like(e.Employee.FullName, $"%{request.Name}%"))
                .OrderByDescending(e => e.DateTime).AsNoTracking();

            return await PaginatedList<EmployeeFault>.CreateAsync(query, request.Page, request.Size);
        }
    }
}
