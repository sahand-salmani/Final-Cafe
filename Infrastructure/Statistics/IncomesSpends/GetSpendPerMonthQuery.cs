using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Common;
using DataAccess.Database;
using Infrastructure.Statistics.SqlQueries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Statistics.IncomesSpends
{
    public class GetSpendPerMonthQuery : IRequest<List<SpendPerMonthVm>>
    {
        public GetSpendPerMonthQuery(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }

        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        [DataType(DataType.Date)]
        public DateTime To { get; set; }
    }

    public class GetSpendPerMonthQueryHandler : IRequestHandler<GetSpendPerMonthQuery, List<SpendPerMonthVm>>
    {
        private readonly DatabaseContext _context;

        public GetSpendPerMonthQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<SpendPerMonthVm>> Handle(GetSpendPerMonthQuery request, CancellationToken cancellationToken)
        {
            if (request.From > request.To)
            {
                return null;
            }

            var query = SqlQuery.SpendPerMonthQuery(request.From, request.To);

            return await _context.SpendPerMonthVms
                .FromSqlRaw($"{query}").ToListAsync(cancellationToken);
        }
    }
}
