using System;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Models
{
    public class RestaurantMeeting : BaseEntity
    {
        [Required, MaxLength(255)]
        public string Subject { get; set; }
        [MaxLength(255)]
        public string Person { get; set; }
        [MaxLength(4000)]
        public string Note { get; set; }
        public int? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        [DataType(DataType.DateTime), Required]
        public DateTime HappensAt { get; set; }

    }
}
