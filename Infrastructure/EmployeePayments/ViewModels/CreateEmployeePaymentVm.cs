using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EmployeePayments.ViewModels
{
    public class CreateEmployeePaymentVm
    {
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal ExtraAmount { get; set; }
        [DataType(DataType.Date)] public DateTime PaidTime { get; set; } = DateTime.Now;
        public int EmployeeId { get; set; }
    }
}
