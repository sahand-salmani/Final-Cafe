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
    public class GetEmployeeFaultsQueryHandler : IRequestHandler<GetEmployeeFaultsQuery, PaginatedList<EmployeeFault>>
    {
        private readonly DatabaseContext _context;

        public GetEmployeeFaultsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<EmployeeFault>> Handle(GetEmployeeFaultsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.EmployeeFaults.OrderByDescending(e => e.DateTime).Include(e => e.Employee).AsNoTracking();

            return await PaginatedList<EmployeeFault>.CreateAsync(query, request.Page, request.Size);
        }
    }
}
