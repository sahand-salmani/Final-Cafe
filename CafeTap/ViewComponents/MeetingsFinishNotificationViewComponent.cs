using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.RestaurantMeetings.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.ViewComponents
{
    public class MeetingsFinishNotificationViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public MeetingsFinishNotificationViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new MeetingsFinishNotificationQuery();
            var result = await _mediator.Send(query);

            return View(result);
        }
    }
}
