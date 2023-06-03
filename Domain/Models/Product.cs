using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyPayment { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal YearlyPayment { get; set; }
        public ICollection<ContractProduct> Contracts { get; set; }

    }
}
