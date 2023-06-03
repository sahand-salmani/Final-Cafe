using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Common
{
    public class RestaurantDebtVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StatusName { get; set; }
        public decimal TotalDebt { get; set; }
        public ICollection<ContractDebtVm> ContractDebtVms { get; set; }

    }
}
