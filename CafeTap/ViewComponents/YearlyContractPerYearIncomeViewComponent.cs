using System.Threading.Tasks;
using Infrastructure.Statistics.IncomesSpends;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.ViewComponents
{
    public class YearlyContractPerYearIncomeViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public YearlyContractPerYearIncomeViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new YearlyContractsIncomePerYearsQuery(1);
            var result = await _mediator.Send(query);

            return View(result);
        }
    }
}
