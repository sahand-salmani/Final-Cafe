using System.ComponentModel.DataAnnotations;

namespace Infrastructure.RestaurantStatuses.ViewModels
{
    public class CreateRestaurantStatusVm
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }
    }
}
