using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Common;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.EmployeePayments.Queries;
using Infrastructure.EmployeePayments.ViewModels;
using Infrastructure.Statistics.SqlQueries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EmployeePayments.QueryHandlers
{
    public class GetEmployeePaymentByMonthQueryHandler : IRequestHandler<GetEmployeePaymentByMonthQuery, List<MonthlyEmployeePaymentVm>>
    {
        private readonly DatabaseContext _context;

        public GetEmployeePaymentByMonthQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<MonthlyEmployeePaymentVm>> Handle(GetEmployeePaymentByMonthQuery request, CancellationToken cancellationToken)
        {

            var queryString = SqlQuery.EmployeePaymentDetails(request.Id, request.StartDate, request.EndDate);

            var query = await _context.MonthlyEmployeePaymentVm.FromSqlRaw(queryString).ToListAsync(cancellationToken);

            return query;
        }
    }
}
