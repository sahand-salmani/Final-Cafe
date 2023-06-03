using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Interns.ViewModels
{
    public class GetInternVm
    {
        public int Id { get; set; }
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
        public bool IsApprovedForJob { get; set; }
    }
}
