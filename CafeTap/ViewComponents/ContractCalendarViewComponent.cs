using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Contracts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.ViewComponents
{
    public class ContractCalendarViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public ContractCalendarViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new GetContractsCalendarQuery();
            var result = await _mediator.Send(query);

            return View(result);
        }
    }
}
