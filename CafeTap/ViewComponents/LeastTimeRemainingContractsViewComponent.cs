using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Contracts.Queries;
using Infrastructure.Statistics.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.ViewComponents
{
    public class LeastTimeRemainingContractsViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public LeastTimeRemainingContractsViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new GetLeastTimeRemainingContractsQuery();
            var result = await _mediator.Send(query);
            return View(result);

        }
    }
}
