using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Contracts.ViewModels
{
    public class ContractNotificationVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string Remaining { get; set; }
        public string RestaurantName { get; set; }
    }
}
