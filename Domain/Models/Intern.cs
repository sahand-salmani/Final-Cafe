using System;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Models
{
    public class Intern : BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        [MaxLength(255)]
        public string Position { get; set; }
        [MaxLength(255)]
        public string University { get; set; }
        [MaxLength(255)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartsAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime FinishedAt { get; set; }
        public bool IsApprovedForJob { get; set; } = false;
    }
}
