using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.PrePayments.ViewModels
{
    public class CreatePrePaymentVm
    {
        public int EmployeeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        [MaxLength(2080)]
        public string Note { get; set; }
    }
}
