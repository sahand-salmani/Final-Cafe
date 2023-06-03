using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Contracts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.ViewComponents
{
    public class ContractFinishNotificationViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public ContractFinishNotificationViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new ContractFinishNotificationQuery();
            var result = await _mediator.Send(query);
            return View(result);
        }
    }
}
