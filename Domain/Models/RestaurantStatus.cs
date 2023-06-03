using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Models
{
    public class RestaurantStatus : BaseEntity
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
