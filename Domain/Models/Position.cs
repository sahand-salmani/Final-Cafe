using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Models
{
    public class Position : BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
