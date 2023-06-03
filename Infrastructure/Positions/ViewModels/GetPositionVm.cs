using System.Collections.Generic;
using Domain.Models;

namespace Infrastructure.Positions.ViewModels
{
    public class GetPositionVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
