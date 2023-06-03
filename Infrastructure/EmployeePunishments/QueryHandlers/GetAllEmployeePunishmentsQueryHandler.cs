using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.EmployeePunishments.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EmployeePunishments.QueryHandlers
{
    public class GetAllEmployeePunishmentsQueryHandler : IRequestHandler<GetAllEmployeePunishmentsQuery, PaginatedList<EmployeePunishment>>
    {
        private readonly DatabaseContext _context;

        public GetAllEmployeePunishmentsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<EmployeePunishment>> Handle(GetAllEmployeePunishmentsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.EmployeePunishments
                .Include(e => e.Employee)
                .OrderByDescending(e => e.At)
                .AsNoTracking();

            return await PaginatedList<EmployeePunishment>.CreateAsync(query, request.Page, request.Size);
        }
    }
}
