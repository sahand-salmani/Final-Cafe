using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Infrastructure.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Statistics.IncomesSpends
{
    public class CurrentMonthIncomeQuery : IRequest<decimal>
    {
    }

    public class CurrentMonthIncomeQueryHandler : IRequestHandler<CurrentMonthIncomeQuery, decimal>
    {
        private readonly DatabaseContext _context;

        public CurrentMonthIncomeQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<decimal> Handle(CurrentMonthIncomeQuery request, CancellationToken cancellationToken)
        {
            DateTime firstDayOfMonth = DateTime.Now.GetFirstDayOfCurrentMonthAz();
            DateTime lastDayOfMonth = DateTime.Now.GetLastDayOfCurrentMonthAz();
            var incomeOfMonth = await _context.ContractPayments
                .Where(e => e.PaidAt >= firstDayOfMonth)
                .Where(e => e.PaidAt <= lastDayOfMonth)
                .SumAsync(e => e.Amount, cancellationToken);

            return incomeOfMonth;

        }
    }
}
