using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class GetIncomePerMonthQuery : IRequest<List<IncomePerMonthVm>>
    {
        public GetIncomePerMonthQuery()
        {
            From = DateTime.Now.GetFirstDayOfCurrentYear();
            To = From.GetLastDayOfCurrentYear();
        }
        public GetIncomePerMonthQuery(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        [DataType(DataType.Date)]
        public DateTime To { get; set; }
    }

    public class GetIncomePerMonthQueryHandler : IRequestHandler<GetIncomePerMonthQuery, List<IncomePerMonthVm>>
    {
        private readonly DatabaseContext _context;

        public GetIncomePerMonthQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<IncomePerMonthVm>> Handle(GetIncomePerMonthQuery request, CancellationToken cancellationToken)
        {
            if (request.From > request.To)
            {
                return null;
            }


            var query = SqlQuery.InComePerMonthQuery(request.From, request.To);
            var result = await _context.IncomePerMonthVms
                .FromSqlRaw($"{query}").ToListAsync(cancellationToken);

            return result;
        }
    }
}
