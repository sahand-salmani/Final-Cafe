using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Contracts.Queries;
using Infrastructure.Contracts.ViewModels;
using Infrastructure.RestaurantMeetings.Queries;
using Infrastructure.RestaurantMeetings.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contracts.QueriesHandlers
{
    public class GetMeetingsCalendarQueryHandler : IRequestHandler<GetContractsCalendarQuery, List<ContractCalendarVm>>
    {
        private readonly DatabaseContext _context;

        public GetMeetingsCalendarQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<ContractCalendarVm>> Handle(GetContractsCalendarQuery request, CancellationToken cancellationToken)
        {
            var now = DateTime.Now.ToAzDateTime();
            var from = now.AddMonths(-5);
            var to = now.AddMonths(5);

            var contracts = await _context
                .Contracts
                .AsNoTracking()
                .Where(e => e.EndDate > from && e.EndDate < to)
                .Select(e => new ContractCalendarVm()
                {
                    Id = e.Id,
                    Title = e.Name,
                    Color = "#681ec9",
                    Start = e.EndDate.Date
                })
                .ToListAsync(cancellationToken);

            return contracts;
        }
    }
}
