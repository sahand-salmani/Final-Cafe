using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Infrastructure.Statistics.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Statistics.Counts
{
    public class EmployeeRestaurantContractCountQuery : IRequest<EmployeeRestaurantContractCountVm>
    {
    }

    public class EmployeeRestaurantContractCountQueryHandler : IRequestHandler<EmployeeRestaurantContractCountQuery, EmployeeRestaurantContractCountVm>
    {
        private readonly DatabaseContext _context;

        public EmployeeRestaurantContractCountQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<EmployeeRestaurantContractCountVm> Handle(EmployeeRestaurantContractCountQuery request, CancellationToken cancellationToken)
        {
            var model = new EmployeeRestaurantContractCountVm();

            var employeeCount = await _context.Employees.CountAsync(cancellationToken);
            var restaurantCount = await _context.Restaurants.CountAsync(cancellationToken);
            var contractCount = await _context.Contracts.CountAsync(cancellationToken);

            model.EmployeeCount = employeeCount;
            model.RestaurantCount = restaurantCount;
            model.ContractCount = contractCount;

            return model;

        }
    }
}
