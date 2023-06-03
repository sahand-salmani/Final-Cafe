using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Statistics.IncomesSpends;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.ViewComponents
{
    public class MonthlyContractPerYearIncomeViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public MonthlyContractPerYearIncomeViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new YearlyContractsIncomePerYearsQuery(0);
            var result = await _mediator.Send(query);

            return View(result);
        }
    }
}
