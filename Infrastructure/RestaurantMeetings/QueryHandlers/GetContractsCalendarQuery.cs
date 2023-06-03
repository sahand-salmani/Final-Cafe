using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.RestaurantMeetings.Queries;
using Infrastructure.RestaurantMeetings.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DateTime = System.DateTime;

namespace Infrastructure.RestaurantMeetings.QueryHandlers
{
    public class GetMeetingsCalendarQueryHandler : IRequestHandler<GetMeetingsCalendarQuery, List<MeetingCalendarVm>>
    {
        private readonly DatabaseContext _context;

        public GetMeetingsCalendarQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<MeetingCalendarVm>> Handle(GetMeetingsCalendarQuery request, CancellationToken cancellationToken)
        {
            var now = DateTime.Now.ToAzDateTime();
            var from = now.AddMonths(-5);
            var to = now.AddMonths(5);

            var meetings = await _context
                .RestaurantMeetings
                .AsNoTracking()
                .Where(e => e.HappensAt > from && e.HappensAt < to)
                .Select(e => new MeetingCalendarVm()
                {
                    Id = e.Id,
                    Title = e.Person,
                    Color = "#0cab6b",
                    Start = e.HappensAt
                })
                .ToListAsync(cancellationToken);


            return meetings;
        }
    }
}
