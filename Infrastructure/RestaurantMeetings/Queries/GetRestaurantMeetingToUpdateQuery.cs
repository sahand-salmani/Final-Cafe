using Infrastructure.RestaurantMeetings.ViewModels;
using MediatR;

namespace Infrastructure.RestaurantMeetings.Queries
{
    public class GetRestaurantMeetingToUpdateQuery : IRequest<UpdateRestaurantMeetingVm>
    {
        public GetRestaurantMeetingToUpdateQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
