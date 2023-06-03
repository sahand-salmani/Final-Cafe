using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Statistics.Counts
{
    public class GetContractCountsQuery : IRequest<int>
    {
    }

    public class GetContractCountsQueryHandler : IRequestHandler<GetContractCountsQuery, int>
    {
        private readonly DatabaseContext _context;

        public GetContractCountsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(GetContractCountsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Contracts.AsNoTracking().CountAsync(cancellationToken);
        }


    }
}
