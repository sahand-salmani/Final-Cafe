using System.ComponentModel.DataAnnotations;

namespace Infrastructure.RestaurantNetworks.ViewModels
{
    public class CreateRestaurantNetworkVm
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }
    }
}
