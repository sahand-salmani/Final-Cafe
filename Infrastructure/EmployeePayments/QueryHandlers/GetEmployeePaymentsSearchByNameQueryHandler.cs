using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.EmployeePayments.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EmployeePayments.QueryHandlers
{
    public class GetEmployeePaymentsSearchByNameQueryHandler : IRequestHandler<GetEmployeePaymentsSearchByNameQuery, PaginatedList<EmployeePayment>>
    {
        private readonly DatabaseContext _context;

        public GetEmployeePaymentsSearchByNameQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<EmployeePayment>> Handle(GetEmployeePaymentsSearchByNameQuery request, CancellationToken cancellationToken)
        {
            var empPayments = _context.EmployeePayments
                .AsNoTracking()
                .Include(e => e.Employee)
                .Where(e => EF.Functions.Like(e.Employee.FullName, $"%{request.Name}%"))
                .OrderBy(p => p.PaidTime);

            return await PaginatedList<EmployeePayment>.CreateAsync(empPayments, request.Page, request.Size);
        }
    }
}
