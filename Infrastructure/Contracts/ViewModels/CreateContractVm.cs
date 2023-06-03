using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Contracts.ViewModels
{
    public class CreateContractVm
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, DataType(DataType.Date)] 
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Required, DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Now;
        public int RestaurantId { get; set; }
        public int EmployeeId { get; set; }
        public bool Yearly { get; set; }
        [Required, Range(0, double.MaxValue)]
        public decimal Payment { get; set; }
        public List<int> ProductsId { get; set; } = new List<int>();
        public SelectList Employees { get; set; }
        public MultiSelectList Products { get; set; }
    }
}
