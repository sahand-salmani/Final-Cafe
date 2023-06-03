using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Models
{
    public class EmployeePayment : BaseEntity
    {
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal ExtraAmount { get; set; }
        [DataType(DataType.Date)]
        public DateTime PaidTime { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
