using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.RestaurantStatuses.Queries;
using Infrastructure.RestaurantStatuses.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantStatuses.QueryHandler
{
    public class GetRestaurantStatusToUpdateQueryHandler : IRequestHandler<GetRestaurantStatusToUpdateQuery, EditRestaurantStatusVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetRestaurantStatusToUpdateQueryHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<EditRestaurantStatusVm> Handle(GetRestaurantStatusToUpdateQuery request, CancellationToken cancellationToken)
        {
            var rs = await _context.RestaurantStatus.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (rs is null)
            {
                return null;
            }

            return _mapper.Map<EditRestaurantStatusVm>(rs);
        }
    }
}
