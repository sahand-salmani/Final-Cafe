using System;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Models
{
    public class EmployeeFault : BaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        [Required, MaxLength(2080)]
        public string Note { get; set; }
        [MaxLength(2080)]
        public string Reason { get; set; }

        public bool IsNotified { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

    }
}
