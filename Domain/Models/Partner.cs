using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Models
{
    public class Partner : BaseEntity
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(2080)]
        public string Note { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartsAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndsAt { get; set; }
    }
}
