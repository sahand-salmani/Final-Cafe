using Domain.Models;

namespace Infrastructure.RestaurantContacts.ViewModels
{
    public class GetRestaurantContactVm : CreateRestaurantContactVm
    {
        public int Id { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
