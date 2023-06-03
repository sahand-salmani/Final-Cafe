using System;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Common;

namespace Infrastructure.RestaurantMeetings.ViewModels
{
    public class CreateMeetingVm
    {
        [Required, MaxLength(255)]
        public string Subject { get; set; }
        [MaxLength(255)]
        public string Person { get; set; }
        [MaxLength(4000)]
        public string Note { get; set; }
        [DataType(DataType.DateTime), Required]
        public DateTime HappensAt { get; set; } = DateTime.Now.ToAzDateTime();
    }
}
