using System;
using System.Collections.Generic;
using System.Text;
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
    public class GetRestaurantMeetingByIdQueryHandler : IRequestHandler<GetRestaurantMeetingByIdQuery, GetRestaurantMeetingVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetRestaurantMeetingByIdQueryHandler(DatabaseContext context,
                                                    IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetRestaurantMeetingVm> Handle(GetRestaurantMeetingByIdQuery request, CancellationToken cancellationToken)
        {
            var restaurantMeeting = await _context.RestaurantMeetings.Include(e => e.Restaurant)
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            return _mapper.Map<GetRestaurantMeetingVm>(restaurantMeeting);
        }
    }
}
