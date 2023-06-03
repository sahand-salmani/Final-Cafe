using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Common
{
    public class ContractDebtVm
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Debt { get; set; }
    }
}
