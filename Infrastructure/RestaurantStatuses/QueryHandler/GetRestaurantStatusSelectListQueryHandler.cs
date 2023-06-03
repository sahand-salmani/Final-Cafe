using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.RestaurantStatuses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantStatuses.QueryHandler
{
    public class GetRestaurantStatusSelectListQueryHandler : IRequestHandler<GetRestaurantStatusSelectListQuery, SelectList>
    {
        private readonly DatabaseContext _context;

        public GetRestaurantStatusSelectListQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<SelectList> Handle(GetRestaurantStatusSelectListQuery request, CancellationToken cancellationToken)
        {
            var statuses = await _context.RestaurantStatus.ToListAsync(cancellationToken);

            if (request.Selected == 0)
            {
                return new SelectList(statuses, nameof(RestaurantStatus.Id), nameof(RestaurantStatus.Name));
            }

            return new SelectList(statuses, nameof(RestaurantStatus.Id), nameof(RestaurantStatus.Name), request.Selected);
        }
    }
}
