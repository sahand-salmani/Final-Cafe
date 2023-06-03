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
    public class UpdateRestaurantMeetingCommandHandler : IRequestHandler<UpdateRestaurantMeetingCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public UpdateRestaurantMeetingCommandHandler(DatabaseContext context,
                                                     IMapper mapper,
                                                     IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<int>> Handle(UpdateRestaurantMeetingCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();
            if (request.Model.RestaurantId != 0)
            {
                var restaurantExists =
                    await _context.Restaurants.AsNoTracking().AnyAsync(e => e.Id == request.Model.RestaurantId, cancellationToken);
                if (!restaurantExists)
                {
                    return result.AddError("Restaurant was not found");
                }
            }
            

            var updated = _mapper.Map<RestaurantMeeting>(request.Model);

            if (request.Model.RestaurantId == 0)
            {
                updated.RestaurantId = null;
            }

            _context.RestaurantMeetings.Update(updated);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = updated.Id;

            return result;

        }
    }
}
