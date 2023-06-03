using System;
using System.Threading.Tasks;
using CafeTap.Controllers.Base;
using Infrastructure.Common;
using Infrastructure.Statistics.IncomesSpends;
using Infrastructure.Statistics.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    [Authorize(Policy = ClaimsList.Statistika)]
    public class StatisticsController : MyController
    {
        [HttpGet]
        public async Task<IActionResult> Search()
        {
            var now = DateTime.Now;
            var start = new DateTime(now.Year, 1, 1);
            var finish = new DateTime(now.Year, 12, 31);


            var query = new GetIncomePerMonthQuery(start, finish);
            var incomeResult = await Mediator.Send(query);

            var spendQuery = new GetSpendPerMonthQuery(start, finish);
            var spendResult = await Mediator.Send(spendQuery);

            GetInComeAndSpendPerMonthInYearVm model = new GetInComeAndSpendPerMonthInYearVm()
            {
                Incomes = incomeResult,
                Spends = spendResult
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SearchByYearAndContractType(int year, int contractType)
        {
            var query = new IncomePerMonthByDateAndContractTypeQuery(year, contractType);
            GetInComeAndSpendPerMonthInYearVm result = await Mediator.Send(query);

            return View(result);
        }


        [HttpGet]
        public IActionResult CurrentYearIncomePerMonth()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MonthlyIncomePerYears()
        {
            return View();
        }


        [HttpGet]
        public IActionResult YearlyContractIncomePerYears()
        {
            return View();
        }
    }
}
