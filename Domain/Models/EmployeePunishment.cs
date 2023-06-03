using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Models
{
    public class EmployeePunishment : BaseEntity
    {
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [MaxLength(2080)]
        public string Note { get; set; }
        [DataType(DataType.Date)]
        public DateTime At { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
