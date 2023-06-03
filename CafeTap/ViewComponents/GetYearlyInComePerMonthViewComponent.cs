using System;
using System.Threading.Tasks;
using Infrastructure.Statistics.IncomesSpends;
using Infrastructure.Statistics.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.ViewComponents
{
    public class GetYearlyInComePerMonthViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public GetYearlyInComePerMonthViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var now = DateTime.Now;
            var start = new DateTime(now.Year, 1, 1);
            var finish = new DateTime(now.Year, 12, 31);


            var query = new GetIncomePerMonthQuery(start, finish);
            var incomeResult = await _mediator.Send(query);

            var spendQuery = new GetSpendPerMonthQuery(start, finish);
            var spendResult = await _mediator.Send(spendQuery);

            var model = new GetInComeAndSpendPerMonthInYearVm()
            {
                Incomes = incomeResult,
                Spends = spendResult
            };


            return View(model);

        }
    }
}
