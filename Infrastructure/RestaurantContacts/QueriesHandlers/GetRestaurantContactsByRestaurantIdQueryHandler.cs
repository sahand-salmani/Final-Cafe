using System.Collections.Generic;
using System.Linq;
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
    public class GetRestaurantContactsByRestaurantIdQueryHandler : IRequestHandler<GetRestaurantContactsByRestaurantIdQuery, List<GetRestaurantContactVm>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetRestaurantContactsByRestaurantIdQueryHandler(DatabaseContext context,
                                                               IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetRestaurantContactVm>> Handle(GetRestaurantContactsByRestaurantIdQuery request, CancellationToken cancellationToken)
        {
            var rc = await _context.RestaurantContacts.Include(e => e.Restaurant).AsNoTracking()
                .Where(e => e.RestaurantId == request.Id)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<GetRestaurantContactVm>>(rc);
        }
    }
}
