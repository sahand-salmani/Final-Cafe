using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.RestaurantNetworks.Queries;
using Infrastructure.RestaurantNetworks.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantNetworks.QueryHandlers
{
    public class GetRestaurantNetworkToUpdateQueryHandler : IRequestHandler<GetRestaurantNetworkToUpdateQuery, EditRestaurantNetworkVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetRestaurantNetworkToUpdateQueryHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<EditRestaurantNetworkVm> Handle(GetRestaurantNetworkToUpdateQuery request, CancellationToken cancellationToken)
        {
            var network = await _context.RestaurantNetworks.AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (network is null)
            {
                return null;
            }


            return _mapper.Map<EditRestaurantNetworkVm>(network);
        }
    }
}
