using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.RestaurantMeetings.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantMeetings.CommandHandlers
{
    public class CreateRestaurantMeetingCommandHandler : IRequestHandler<CreateRestaurantMeetingCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateRestaurantMeetingCommandHandler(DatabaseContext context,
                                                     IMapper mapper,
                                                     IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<int>> Handle(CreateRestaurantMeetingCommand request, CancellationToken cancellationToken)
        {

            request.Model.HappensAt = request.Model.HappensAt.ToAzDateTime();

            var result = new OperationResult<int>();
            var restaurantExists = await _context.Restaurants.AsNoTracking()
                .AnyAsync(e => e.Id == request.Model.RestaurantId, cancellationToken);

            if (!restaurantExists)
            {
                return result.AddError("Restaurant was not found");
            }


            var newMeeting = _mapper.Map<RestaurantMeeting>(request.Model);

            await _context.RestaurantMeetings.AddAsync(newMeeting, cancellationToken);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            result.Entity = newMeeting.Id;

            return result;
        }
    }
}
