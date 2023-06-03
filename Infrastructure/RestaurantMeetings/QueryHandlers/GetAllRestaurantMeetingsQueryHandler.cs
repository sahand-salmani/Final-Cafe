using System.Linq;
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
    public class GetAllRestaurantMeetingsQueryHandler : IRequestHandler<GetAllRestaurantMeetingsQuery, PaginatedList<RestaurantMeeting>>
    {
        private readonly DatabaseContext _context;

        public GetAllRestaurantMeetingsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<RestaurantMeeting>> Handle(GetAllRestaurantMeetingsQuery request, CancellationToken cancellationToken)
        {
            var meetings = _context.RestaurantMeetings.Include(e => e.Restaurant).AsNoTracking().OrderByDescending(e => e.HappensAt);

            return await PaginatedList<RestaurantMeeting>.CreateAsync(meetings, request.Page, request.Size);
        }
    }
}
