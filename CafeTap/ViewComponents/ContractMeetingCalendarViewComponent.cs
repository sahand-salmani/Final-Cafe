using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Contracts.Queries;
using Infrastructure.RestaurantMeetings.Queries;
using Infrastructure.RestaurantMeetings.ViewModels;
using Infrastructure.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.ViewComponents
{
    public class ContractMeetingCalendarViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public ContractMeetingCalendarViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new ContractMeetingCalendarVm();

            var contractCalendarQuery = new GetContractsCalendarQuery();
            var contractCalendarResult = await _mediator.Send(contractCalendarQuery);
            model.ContractCalendarVm = contractCalendarResult;

            var meetingsCalendarQuery = new GetMeetingsCalendarQuery();
            List<MeetingCalendarVm> meetingCalendarResult = await _mediator.Send(meetingsCalendarQuery);
            model.MeetingCalendarVm = meetingCalendarResult;

            return View(model);
        }
    }
}
