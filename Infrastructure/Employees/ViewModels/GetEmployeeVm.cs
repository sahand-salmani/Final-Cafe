using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models;

namespace Infrastructure.Employees.ViewModels
{
    public class GetEmployeeVm
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string FullName { get; set; }
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        [MaxLength(55), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [MaxLength(1080)]
        public string Address { get; set; }
        public Position Position { get; set; }
        public List<EmployeePayment> EmployeePayments { get; set; } = new List<EmployeePayment>();
    }
}
