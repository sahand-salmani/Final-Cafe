using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Models
{
    public class Restaurant : BaseEntity
    {
        [MaxLength(255), Required]
        public string Name { get; set; }
        [Required, MaxLength(1080)]
        public string Address { get; set; }
        [Required, MaxLength(55), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [MaxLength(255)]
        public ICollection<Contract> Contract { get; set; }
        [MaxLength(255), Required]
        public string City { get; set; }

        public RestaurantStatus RestaurantStatus { get; set; }
        public int RestaurantStatusId { get; set; }

        public RestaurantNetwork RestaurantNetworks { get; set; }
        public int? RestaurantNetworkId { get; set; }

        public ICollection<Stant> Stants { get; set; }
        public ICollection<RestaurantContact> RestaurantContacts { get; set; }
        public ICollection<RestaurantMeeting> RestaurantMeetings { get; set; }

        [NotMapped]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalDebts { get; set; }

    }
}
