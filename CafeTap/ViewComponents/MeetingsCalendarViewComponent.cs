using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.RestaurantMeetings.Queries;
using Infrastructure.RestaurantMeetings.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.ViewComponents
{
    public class MeetingsCalendarViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public MeetingsCalendarViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var scheme = Request.Scheme;
            var host = Request.Host;
            PathString path = Request.Path;
            var query = new GetMeetingsCalendarQuery();
            List<MeetingCalendarVm> result = await _mediator.Send(query);
            return View(result);
        }
    }
}
