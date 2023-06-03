using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Contracts.ViewModels
{
    public class ContractCalendarVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public DateTime Start { get; set; }
        public string Url { get; set; }
    }
}
