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
    public class GetRestaurantCountQuery : IRequest<int>
    {
    }

    public class GetRestaurantCountQueryHandler : IRequestHandler<GetRestaurantCountQuery, int>
    {
        private readonly DatabaseContext _context;

        public GetRestaurantCountQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(GetRestaurantCountQuery request, CancellationToken cancellationToken)
        {
            return await _context.Restaurants.AsNoTracking().CountAsync(cancellationToken);
        }
    }
}
