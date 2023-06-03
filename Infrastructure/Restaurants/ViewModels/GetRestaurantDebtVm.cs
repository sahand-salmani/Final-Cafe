using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Infrastructure.Contracts.ViewModels;

namespace Infrastructure.Restaurants.ViewModels
{
    public class GetRestaurantDebtVm : List<Restaurant>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string Network { get; set; }
        public decimal TotalDebt { get; set; }
        public List<GetContractVm> Contract { get; set; }
    }
}
