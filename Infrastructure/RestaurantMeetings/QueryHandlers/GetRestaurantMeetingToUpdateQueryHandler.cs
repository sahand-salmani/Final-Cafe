using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.RestaurantMeetings.Queries;
using Infrastructure.RestaurantMeetings.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantMeetings.QueryHandlers
{
    public class GetRestaurantMeetingToUpdateQueryHandler : IRequestHandler<GetRestaurantMeetingToUpdateQuery, UpdateRestaurantMeetingVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetRestaurantMeetingToUpdateQueryHandler(DatabaseContext context,
                                                        IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UpdateRestaurantMeetingVm> Handle(GetRestaurantMeetingToUpdateQuery request, CancellationToken cancellationToken)
        {
            var rm = await _context.RestaurantMeetings.AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            return rm is null ? null : _mapper.Map<UpdateRestaurantMeetingVm>(rm);
        }
    }
}
