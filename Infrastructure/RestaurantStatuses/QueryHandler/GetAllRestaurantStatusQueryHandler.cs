using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.RestaurantStatuses.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantStatuses.QueryHandler
{
    public class GetAllRestaurantStatusQueryHandler : IRequestHandler<GetAllRestaurantStatusQuery, PaginatedList<RestaurantStatus>>
    {
        private readonly DatabaseContext _context;

        public GetAllRestaurantStatusQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<RestaurantStatus>> Handle(GetAllRestaurantStatusQuery request, CancellationToken cancellationToken)
        {
            var rs = _context.RestaurantStatus.AsNoTracking();

            return await PaginatedList<RestaurantStatus>.CreateAsync(rs, request.Page, request.Size);
        }
    }
}
