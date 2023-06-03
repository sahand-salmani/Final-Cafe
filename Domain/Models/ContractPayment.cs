using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Models
{
    public class ContractPayment : BaseEntity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime PaidAt { get; set; }
        public Contract Contract { get; set; }
        public int ContractId { get; set; }
    }
}
