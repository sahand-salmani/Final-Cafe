using System;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Common;

namespace Infrastructure.EmployeeFaults.ViewModels
{
    public class CreateEmployeeFaultVm
    {
        [DataType(DataType.Date)] public DateTime DateTime { get; set; } = DateTime.Now.ToAzDateTime();
        [Required, MaxLength(2080)]
        public string Note { get; set; }
        [MaxLength(2080)]
        public string Reason { get; set; }
        public int EmployeeId { get; set; }
        public bool IsNotified { get; set; }
    }
}
