using Infrastructure.RestaurantMeetings.ViewModels;
using MediatR;

namespace Infrastructure.RestaurantMeetings.Queries
{
    public class GetRestaurantMeetingByIdQuery : IRequest<GetRestaurantMeetingVm>
    {
        public GetRestaurantMeetingByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
