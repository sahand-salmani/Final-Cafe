using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.RestaurantMeetings.Queries
{
    public class GetAllRestaurantMeetingsQuery : IRequest<PaginatedList<RestaurantMeeting>>
    {
        public GetAllRestaurantMeetingsQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
