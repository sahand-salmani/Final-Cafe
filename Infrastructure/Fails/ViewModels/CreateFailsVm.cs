using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Fails.ViewModels
{
    public class CreateFailsVm
    {
        public int EmployeeId { get; set; }
        [MaxLength(255)]
        public string Restaurant { get; set; }
        [MaxLength(2080)]
        public string Note { get; set; }
        [DataType(DataType.Date)]
        public DateTime HappenedAt { get; set; }
        public SelectList SelectList { get; set; }
    }
}
