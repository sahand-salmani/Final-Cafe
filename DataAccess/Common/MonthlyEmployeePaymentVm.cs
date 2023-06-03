using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Common
{
    public class MonthlyEmployeePaymentVm
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PaymentAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Extras { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrePaid { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Punishments { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalReceived { get; set; }
    }
}
