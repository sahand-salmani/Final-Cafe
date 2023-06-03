using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.PrePayments.ViewModels
{
    public class EditPrePaymentVm
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [MaxLength(2080)]
        public string Note { get; set; }
    }
}
