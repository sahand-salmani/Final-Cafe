using System;
using Domain.Models;

namespace Infrastructure.Fails.ViewModels
{
    public class GetFailsVm
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public string Restaurant { get; set; }
        public string Note { get; set; }
        public DateTime HappenedAt { get; set; }
    }
}
