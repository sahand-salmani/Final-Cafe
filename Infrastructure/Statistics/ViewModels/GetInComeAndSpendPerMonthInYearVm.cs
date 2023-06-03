using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Common;

namespace Infrastructure.Statistics.ViewModels
{
    public class GetInComeAndSpendPerMonthInYearVm
    {
        public List<IncomePerMonthVm> Incomes { get; set; } = new List<IncomePerMonthVm>();
        public List<SpendPerMonthVm> Spends { get; set; } = new List<SpendPerMonthVm>();
    }
}
