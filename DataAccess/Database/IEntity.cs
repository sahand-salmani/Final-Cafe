using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Database
{
    public interface IEntity
    {
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractProduct> ContractProducts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePayment> EmployeePayments { get; set; }
        public DbSet<Intern> Interns { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Spend> Spends { get; set; }
        public DbSet<Stant> Stants { get; set; }
    }
}
