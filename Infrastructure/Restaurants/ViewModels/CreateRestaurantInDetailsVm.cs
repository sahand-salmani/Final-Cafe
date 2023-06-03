using Infrastructure.RestaurantContacts.ViewModels;

namespace Infrastructure.Restaurants.ViewModels
{
    public class CreateRestaurantInDetailsVm
    {
        public CreateRestaurantVm CreateRestaurantVm { get; set; }
        public CreateRestaurantContactVm CreateRestaurantContactVm { get; set; }
    }
}
