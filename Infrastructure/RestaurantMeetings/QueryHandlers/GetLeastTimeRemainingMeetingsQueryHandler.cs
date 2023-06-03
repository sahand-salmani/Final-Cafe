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
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantMeetings.QueryHandlers
{
    public class GetLeastTimeRemainingMeetingsQueryHandler : IRequestHandler<GetLeastTimeRemainingMeetingsQuery, List<RestaurantMeeting>>
    {
        private readonly DatabaseContext _context;

        public GetLeastTimeRemainingMeetingsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<RestaurantMeeting>> Handle(GetLeastTimeRemainingMeetingsQuery request, CancellationToken cancellationToken)
        {
            var dateTimeNowAz = DateTime.Now.ToAzDateTime();
            var result =  await _context.RestaurantMeetings
                .AsNoTracking()
                .Include(e => e.Restaurant)
                .Where(e => dateTimeNowAz < e.HappensAt)
                .OrderBy(e => e.HappensAt)
                .Take(5)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
