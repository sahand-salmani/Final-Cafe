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
    public class GetCountOfTQuery<T> : IRequest<int> where T: class
    {
    }

    public class GetCountOfTQueryHandler<T> : IRequestHandler<GetCountOfTQuery<T>, int> where T: class
    {
        private readonly DatabaseContext _context;

        public GetCountOfTQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(GetCountOfTQuery<T> request, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().CountAsync(cancellationToken);
        }
    }
}
