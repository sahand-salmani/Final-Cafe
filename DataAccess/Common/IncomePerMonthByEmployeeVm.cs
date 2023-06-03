using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Common
{
    public class IncomePerMonthByEmployeeVm
    {
        public int Year { get; set; }
        public int Month { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public int Total { get; set; }

    }
}
