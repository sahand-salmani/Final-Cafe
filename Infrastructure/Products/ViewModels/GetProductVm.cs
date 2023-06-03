using System.Collections.Generic;
using Domain.Models;

namespace Infrastructure.Products.ViewModels
{
    public class GetProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal YearlyPayment { get; set; }
        public List<ContractProduct> Contracts { get; set; } = new List<ContractProduct>();
    }
}
