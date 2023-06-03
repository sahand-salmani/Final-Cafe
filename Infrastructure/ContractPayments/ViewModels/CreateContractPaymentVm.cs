using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.ContractPayments.ViewModels
{
    public class CreateContractPaymentVm
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime PaidAt { get; set; }
        public int ContractId { get; set; }
    }
}
