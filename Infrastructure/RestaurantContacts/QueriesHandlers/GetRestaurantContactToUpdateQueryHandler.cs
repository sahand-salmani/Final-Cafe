using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.RestaurantContacts.Queries;
using Infrastructure.RestaurantContacts.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantContacts.QueriesHandlers
{
    public class GetRestaurantContactToUpdateQueryHandler : IRequestHandler<GetRestaurantContactToUpdateQuery, UpdateRestaurantContactVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetRestaurantContactToUpdateQueryHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UpdateRestaurantContactVm> Handle(GetRestaurantContactToUpdateQuery request, CancellationToken cancellationToken)
        {
            var rc = await _context.RestaurantContacts.AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            return _mapper.Map<UpdateRestaurantContactVm>(rc);
        }
    }
}
