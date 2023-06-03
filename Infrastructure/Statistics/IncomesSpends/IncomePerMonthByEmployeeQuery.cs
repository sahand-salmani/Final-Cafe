using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Common;
using DataAccess.Database;
using Infrastructure.Common;
using Infrastructure.Statistics.SqlQueries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Statistics.IncomesSpends
{
    public class IncomePerMonthByEmployeeQuery : IRequest<List<IncomePerMonthByEmployeeVm>>
    {
        public IncomePerMonthByEmployeeQuery(int id)
        {
            EmployeeId = id;
            Starts = new DateTime().GetFirstDayOfCurrentYear();
            Ends = new DateTime().GetLastDayOfCurrentYear();
        }
        public IncomePerMonthByEmployeeQuery(int employeeId, DateTime starts, DateTime ends)
        {
            EmployeeId = employeeId;
            Starts = starts;
            Ends = ends;
        }
        public int EmployeeId { get; set; }
        public DateTime Starts { get; set; }
        public DateTime Ends { get; set; }
    }

    public class IncomePerMonthByEmployeeQueryHandler : IRequestHandler<IncomePerMonthByEmployeeQuery, List<IncomePerMonthByEmployeeVm>>
    {
        private readonly DatabaseContext _context;

        public IncomePerMonthByEmployeeQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<IncomePerMonthByEmployeeVm>> Handle(IncomePerMonthByEmployeeQuery request, CancellationToken cancellationToken)
        {
            if (request.Starts > request.Ends)
            {
                return null;
            }

            var employeeExists = await _context.Employees.AnyAsync(e => e.Id == request.EmployeeId, cancellationToken);

            if (!employeeExists)
            {
                return null;
            }

            var query = SqlQuery.IncomeThatEmployeeMadePerMonth(request.Starts, request.Ends, request.EmployeeId);

            List<IncomePerMonthByEmployeeVm> queryResult = await _context.IncomePerMonthByEmployeeVms
                .FromSqlRaw(query)
                .ToListAsync(cancellationToken);

            return queryResult;
        }
    }
}
