using Infrastructure.RestaurantContacts.ViewModels;
using MediatR;

namespace Infrastructure.RestaurantContacts.Queries
{
    public class GetRestaurantContactToUpdateQuery : IRequest<UpdateRestaurantContactVm>
    {
        public GetRestaurantContactToUpdateQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
