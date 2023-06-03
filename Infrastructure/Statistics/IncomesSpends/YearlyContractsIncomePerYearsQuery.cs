using System;
using System.Collections.Generic;
using System.Text;
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
    public class YearlyContractsIncomePerYearsQuery : IRequest<List<IncomePerYearAndContractTypeVm>>
    {
        public YearlyContractsIncomePerYearsQuery(int contractType)
        {
            ContractType = contractType;
            StartDate = DateTime.Now.ToAzDateTime().AddYears(-6);
            EndDate = StartDate.AddYears(12);
        }

        public YearlyContractsIncomePerYearsQuery(int contractType, DateTime startDate, DateTime endDate)
        {
            ContractType = contractType;
            StartDate = startDate;
            EndDate = endDate;
        }
        public int ContractType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class YearlyContractsIncomePerYearsQueryHandler : IRequestHandler<YearlyContractsIncomePerYearsQuery, List<IncomePerYearAndContractTypeVm>>
    {
        private readonly DatabaseContext _context;

        public YearlyContractsIncomePerYearsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<IncomePerYearAndContractTypeVm>> Handle(YearlyContractsIncomePerYearsQuery request, CancellationToken cancellationToken)
        {
            if (request.StartDate > request.EndDate)
            {
                return null;
            }

            var query = SqlQuery.InComePerYearAndContractType(request.StartDate, request.EndDate, request.ContractType);

            return await _context.IncomePerYearAndContractTypeVms.FromSqlRaw(query).ToListAsync(cancellationToken);
        }
    }
}
