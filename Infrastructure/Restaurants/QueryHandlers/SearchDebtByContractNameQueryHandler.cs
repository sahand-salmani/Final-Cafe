using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Restaurants.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Restaurants.QueryHandlers
{
    public class SearchDebtByContractNameQueryHandler : IRequestHandler<SearchDebtByContractNameQuery, PaginatedList<Restaurant>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public SearchDebtByContractNameQueryHandler(DatabaseContext context,
                                                    IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<Restaurant>> Handle(SearchDebtByContractNameQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Restaurants
                .AsNoTracking()
                .Include(e => e.Contract)
                .ThenInclude(e => e.ContractPayments)
                .Include(e => e.Contract)
                .ThenInclude(e => e.Employee)
                .Include(e => e.RestaurantNetworks)
                .Include(e => e.RestaurantStatus)
                .Where(e => e.Contract.Any(c => EF.Functions.Like(c.Name, $"%{request.Name}%")))
                .Where(e => e.Contract.Any(c => c.Payment > c.ContractPayments.Sum(s => s.Amount)) || e.Contract.Any(c => !c.ContractPayments.Any()));

            var model = await PaginatedList<Restaurant>.CreateAsync(query, request.Page, request.Size);


            foreach (var restaurant in model)
            {
                var totalAmount = restaurant.Contract.Sum(c => c.Payment);
                decimal totalPaid = 0;
                foreach (var contract in restaurant.Contract)
                {
                    totalPaid += contract.ContractPayments.Sum(e => e.Amount);
                }
                restaurant.TotalDebts = totalAmount - totalPaid;
            }

            foreach (var getContractVm in model.SelectMany(getRestaurantDebtVm => getRestaurantDebtVm.Contract))
            {
                getContractVm.Remains = getContractVm.Payment - getContractVm.ContractPayments.Sum(e => e.Amount);
            }

            return model;
        }
    }
}
