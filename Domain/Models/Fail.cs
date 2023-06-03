using System;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Models
{
    public class Fail : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [MaxLength(255)]
        public string Restaurant { get; set; }
        [MaxLength(2080)]
        public string Note { get; set; }
        [DataType(DataType.Date)]
        public DateTime HappenedAt { get; set; }

    }
}
