using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Models
{
    public class RestaurantContact : BaseEntity
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Position { get; set; }
        [MaxLength(255)]
        public string PhoneNumber { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
