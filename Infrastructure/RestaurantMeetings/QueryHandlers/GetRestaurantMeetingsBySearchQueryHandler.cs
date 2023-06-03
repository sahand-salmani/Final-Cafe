using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.RestaurantMeetings.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantMeetings.QueryHandlers
{
    public class GetRestaurantMeetingsBySearchQueryHandler : IRequestHandler<GetRestaurantMeetingsBySearchQuery, PaginatedList<RestaurantMeeting>>
    {
        private readonly DatabaseContext _context;

        public GetRestaurantMeetingsBySearchQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<RestaurantMeeting>> Handle(GetRestaurantMeetingsBySearchQuery request, CancellationToken cancellationToken)
        {
            var meetings = _context.RestaurantMeetings
                .Include(e => e.Restaurant)
                .AsNoTracking()
                .Where(e => EF.Functions.Like(e.Person, $"{request.Name}") || EF.Functions.Like(e.Subject, $"{request.Name}"))
                .OrderByDescending(e => e.HappensAt);

            return await PaginatedList<RestaurantMeeting>.CreateAsync(meetings, request.Page, request.Size);
        }
    }
}
