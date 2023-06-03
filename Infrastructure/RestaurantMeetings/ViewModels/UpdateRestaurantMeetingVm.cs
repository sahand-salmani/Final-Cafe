using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.RestaurantMeetings.ViewModels
{
    public class UpdateRestaurantMeetingVm
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Subject { get; set; }
        [MaxLength(255)]
        public string Person { get; set; }
        [MaxLength(4000)]
        public string Note { get; set; }
        public int RestaurantId { get; set; }
        [DataType(DataType.DateTime), Required]
        public DateTime HappensAt { get; set; }
    }
}
