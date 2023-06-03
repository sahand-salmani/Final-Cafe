using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Statistics.Counts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.ViewComponents
{
    public class CountInfoViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public CountInfoViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new EmployeeRestaurantContractCountQuery();
            var result = await _mediator.Send(query);
            return View(result);
        }
    }
}
