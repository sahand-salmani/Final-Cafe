using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Models
{
    public class Employee : BaseEntity
    {
        [Required, MaxLength(255)]
        public string FullName { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        [MaxLength(55), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [MaxLength(1080)]
        public string Address { get; set; }

        public Position Position { get; set; }
        public int PositionId { get; set; }

        public bool CanMakeContract { get; set; }

        public ICollection<EmployeePayment> EmployeePayments { get; set; }
        public ICollection<EmployeePunishment> EmployeePunishments { get; set; }
        public ICollection<EmployeeFault> EmployeeFaults { get; set; }
        public ICollection<PrePayment> PrePayments { get; set; }
    }
}
