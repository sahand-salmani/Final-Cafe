using DataAccess.Common;
using Domain.Models;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Database
{
    public class DatabaseContext : 
        IdentityDbContext<ApplicationUser,ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

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
        public DbSet<Fail> Fails { get; set; }
        public DbSet<PrePayment> PrePayments { get; set; }
        public DbSet<RestaurantContact> RestaurantContacts { get; set; }
        public DbSet<RestaurantMeeting> RestaurantMeetings { get; set; }
        public DbSet<ContractPayment> ContractPayments { get; set; }
        public DbSet<UserRegisterToken> UserRegisterTokens { get; set; }
        public DbSet<RestaurantStatus> RestaurantStatus { get; set; }
        public DbSet<EmployeePunishment> EmployeePunishments { get; set; }
        public DbSet<EmployeeFault> EmployeeFaults { get; set; }
        public DbSet<BlackList> BlackLists { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<RestaurantNetwork> RestaurantNetworks { get; set; }



        // View Models to fetch data by sql command
        public DbSet<IncomePerMonthVm> IncomePerMonthVms { get; set; }
        public DbSet<SpendPerMonthVm> SpendPerMonthVms { get; set; }
        public DbSet<IncomePerMonthByEmployeeVm> IncomePerMonthByEmployeeVms { get; set; }
        public DbSet<IncomePerYearAndContractTypeVm> IncomePerYearAndContractTypeVms { get; set; }
        public DbSet<MonthlyEmployeePaymentVm> MonthlyEmployeePaymentVm { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ContractProduct>().HasKey(e => new { e.ContractId, e.ProductId });
            builder.Entity<ContractProduct>().HasOne(e => e.Contract).WithMany(e => e.ContractProducts)
                .HasForeignKey(e => e.ContractId);
            builder.Entity<ContractProduct>().HasOne(e => e.Product).WithMany(e => e.Contracts)
                .HasForeignKey(e => e.ProductId);

            builder.Entity<Restaurant>().HasIndex(e => e.Name).IsUnique();
            builder.Entity<Position>().HasIndex(e => e.Name).IsUnique();

            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.Users)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.Roles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });


            builder.Entity<IncomePerMonthVm>().HasNoKey();
            builder.Entity<SpendPerMonthVm>().HasNoKey();
            builder.Entity<IncomePerMonthByEmployeeVm>().HasNoKey();
            builder.Entity<IncomePerYearAndContractTypeVm>().HasNoKey();
            builder.Entity<MonthlyEmployeePaymentVm>().HasNoKey();

            builder.AddSeedUser();
        }
    }
}
