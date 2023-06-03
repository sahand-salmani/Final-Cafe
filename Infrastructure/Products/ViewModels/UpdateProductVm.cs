using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Products.ViewModels
{
    public class UpdateProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyPayment { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal YearlyPayment { get; set; }
    }
}
