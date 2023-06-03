using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models;

namespace Infrastructure.ContractPayments.ViewModels
{
    public class GetContractPaymentVm
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime PaidAt { get; set; }
        public Contract Contract { get; set; }
    }
}
