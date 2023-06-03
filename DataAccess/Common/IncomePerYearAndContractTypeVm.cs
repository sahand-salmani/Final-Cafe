using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Common
{
    public class IncomePerYearAndContractTypeVm
    {
        public int Year { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public int Total { get; set; }
        public int ContractType { get; set; }
    }
}
