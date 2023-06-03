using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Common;
using DataAccess.Database;
using Infrastructure.Common;
using Infrastructure.Statistics.SqlQueries;
using Infrastructure.Statistics.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Statistics.IncomesSpends
{
    public class IncomePerMonthByDateAndContractTypeQuery : IRequest<GetInComeAndSpendPerMonthInYearVm>
    {
        public IncomePerMonthByDateAndContractTypeQuery(int year, int contractType)
        {
            Year = year;
            ContractType = contractType;
            Starts = new DateTime(year, 1, 1);
            Ends = Starts.GetLastDayOfGivenYear();
        }
        public int Year { get; set; }
        public int ContractType { get; set; }
        public DateTime Starts { get; set; }
        public DateTime Ends { get; set; }
    }

    public class IncomePerMonthByDateAndContractTypeQueryHandler : IRequestHandler<IncomePerMonthByDateAndContractTypeQuery, GetInComeAndSpendPerMonthInYearVm>
    {
        private readonly DatabaseContext _context;

        public IncomePerMonthByDateAndContractTypeQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<GetInComeAndSpendPerMonthInYearVm> Handle(IncomePerMonthByDateAndContractTypeQuery request, CancellationToken cancellationToken)
        {
            var model = new GetInComeAndSpendPerMonthInYearVm();

            if (request.ContractType == 0)
            {
                List<IncomePerMonthVm> incomesWithoutContractType = await _context.IncomePerMonthVms
                    .FromSqlRaw(
                        SqlQuery.IncomePerMonthByDateAndContractType(request.Starts, request.Ends, request.ContractType))
                    .ToListAsync(cancellationToken);
                model.Incomes = incomesWithoutContractType;
            }
            else if(request.ContractType == 1)
            {
                List<IncomePerMonthVm> incomesWithContractType = await _context.IncomePerMonthVms
                    .FromSqlRaw(
                        SqlQuery.IncomePerMonthByDateAndContractType(request.Starts, request.Ends, request.ContractType))
                    .ToListAsync(cancellationToken);
                model.Incomes = incomesWithContractType;
            }
            else
            {
                List<IncomePerMonthVm> totalIncomeWithContractType = await _context.IncomePerMonthVms
                    .FromSqlRaw(SqlQuery.InComePerMonthQuery(request.Starts, request.Ends)).ToListAsync(cancellationToken);

                model.Incomes = totalIncomeWithContractType;
            }


            var spends = await _context.SpendPerMonthVms
                .FromSqlRaw(SqlQuery.SpendPerMonthQuery(request.Starts, request.Ends))
                .ToListAsync(cancellationToken);

            model.Spends = spends;
            

            return model;
        }
    }
}
