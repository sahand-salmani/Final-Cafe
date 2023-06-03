using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Restaurants.ViewModels
{
    public class CreateRestaurantVm
    {
        [MaxLength(255), Required]

        public string Name { get; set; }
        [Required, MaxLength(1080)]
        public string Address { get; set; }
        [Required, MaxLength(55), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [MaxLength(255), Required]
        public string City { get; set; }

        public SelectList Status { get; set; }
        public int StatusId { get; set; }

        public SelectList Networks { get; set; }
        public int NetworkId { get; set; }

    }
}
