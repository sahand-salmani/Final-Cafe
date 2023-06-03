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
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contracts.QueriesHandlers
{
    public class GetLeastTimeRemainingContractsQueryHandler : IRequestHandler<GetLeastTimeRemainingContractsQuery, List<Contract>>
    {
        private readonly DatabaseContext _context;

        public GetLeastTimeRemainingContractsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<Contract>> Handle(GetLeastTimeRemainingContractsQuery request, CancellationToken cancellationToken)
        {
            var dateTimeNowAz = DateTime.Now.ToAzDateTime();
            return await _context.Contracts
                .Include(e => e.Employee)
                .Include(e => e.Restaurant)
                .Where(e => dateTimeNowAz < e.EndDate)
                .OrderBy(e => e.EndDate)
                .Take(5)
                .ToListAsync(cancellationToken);
        }
    }
}
