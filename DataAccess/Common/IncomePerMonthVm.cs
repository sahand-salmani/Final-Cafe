using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Common
{
    public class IncomePerMonthVm
    {
        public int Month { get; set; }
        public int Year { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
    }
}
