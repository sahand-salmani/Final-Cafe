using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Common;

namespace Infrastructure.Statistics.Utilities
{
    public static class HandleInComePerMonth
    {
        public static List<IncomePerMonthVm> Handle(List<IncomePerMonthVm> incomes)
        {
            if (incomes!= null)
            {
                if (!incomes.Any())
                {
                    return new List<IncomePerMonthVm>();
                }
            }
            var range = Enumerable.Range(1, 12).ToList();


            // ReSharper disable once AssignNullToNotNullAttribute
            if (range.All(e => incomes.Any(q => q.Month == e)))
            {
                return incomes;
            }

            var notExistingMonths = range.Where(e => !incomes.Any(q => q.Month == e)).ToList();

            int year = incomes.FirstOrDefault()!.Year;

            var toAddMonths = notExistingMonths.Select(e => new IncomePerMonthVm()
            {
                Month = e,
                Year = year,
                Total = 0
            }).ToList();


            incomes.AddRange(toAddMonths);


            return incomes.OrderBy(e => e.Month).ToList();

        }
    }
}
