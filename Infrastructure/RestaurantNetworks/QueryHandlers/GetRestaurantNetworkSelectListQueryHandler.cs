using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.RestaurantNetworks.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantNetworks.QueryHandlers
{
    public class GetRestaurantNetworkSelectListQueryHandler : IRequestHandler<GetRestaurantNetworkSelectListQuery, SelectList>
    {
        private readonly DatabaseContext _context;

        public GetRestaurantNetworkSelectListQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<SelectList> Handle(GetRestaurantNetworkSelectListQuery request, CancellationToken cancellationToken)
        {
            var networks = await _context.RestaurantNetworks.AsNoTracking().ToListAsync(cancellationToken);

            var noNetwork = new RestaurantNetwork()
            {
                Id = 0,
                Name = "Yoxdur"
            };

            networks.Insert(0, noNetwork);

            if (request.Id != 0)
            {
                if (await _context.RestaurantNetworks.AnyAsync(e => e.Id == request.Id, cancellationToken))
                {
                    return new SelectList(networks, nameof(RestaurantNetwork.Id), nameof(RestaurantNetwork.Name), request.Id);
                }
            }

            return new SelectList(networks, nameof(RestaurantNetwork.Id), nameof(RestaurantNetwork.Name), noNetwork.Id);
        }
    }
}
