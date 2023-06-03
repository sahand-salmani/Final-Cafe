using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Domain.Models;
using Humanizer;
using Humanizer.Localisation;
using Infrastructure.Common;
using Infrastructure.Contracts.ViewModels;
using Infrastructure.RestaurantMeetings.Queries;
using Infrastructure.RestaurantMeetings.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantMeetings.QueryHandlers
{
    public class MeetingsFinishNotificationQueryHandler : IRequestHandler<MeetingsFinishNotificationQuery, List<MeetingNotificationVm>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public MeetingsFinishNotificationQueryHandler(DatabaseContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<MeetingNotificationVm>> Handle(MeetingsFinishNotificationQuery request, CancellationToken cancellationToken)
        {
            if (request.Days == 0)
            {
                return new List<MeetingNotificationVm>();
            }

            var now = DateTime.Now.ToAzDateTime();
            var wantedTime = DateTime.Now.ToAzDateTime().AddDays(request.Days);


            var contracts = await _context.RestaurantMeetings
                .Where(e => e.HappensAt < wantedTime)
                .Where(e => e.HappensAt > now)
                .Include(e => e.Restaurant)
                .Take(request.Count)
                .Select(e => new RestaurantMeeting()
                {
                    Id = e.Id,
                    Subject = e.Subject,
                    HappensAt = e.HappensAt,
                    Person = e.Person
                })
                .ToListAsync(cancellationToken);

            var results = _mapper.Map<List<MeetingNotificationVm>>(contracts);
            var cultInfo = CultureInfo.GetCultureInfo("az-Latn-AZ");
            foreach (var result in results)
            {
                result.Remaining = (now - result.HappensAt).Humanize(2, maxUnit: TimeUnit.Day, minUnit: TimeUnit.Hour, culture: cultInfo);
            }
            return results;
        }
    }
}
