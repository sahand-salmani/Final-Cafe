using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models;
using Infrastructure.Restaurants.ViewModels;

namespace Infrastructure.Contracts.ViewModels
{
    public class GetContractVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required, Range(0, double.MaxValue)]
        public decimal Payment { get; set; }
        public GetRestaurantVm Restaurant { get; set; }
        public Employee Employee { get; set; }
        public List<ContractProduct> ContractProducts { get; set; } = new List<ContractProduct>();
        public List<ContractPayment> ContractPayments { get; set; } = new List<ContractPayment>();
        public string ContractType { get; set; }
        public decimal Remains { get; set; }

    }
}
