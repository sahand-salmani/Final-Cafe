using System.Threading;
using System.Threading.Tasks;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.RestaurantMeetings.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantMeetings.CommandHandlers
{
    public class DeleteRestaurantMeetingCommandHandler : IRequestHandler<DeleteRestaurantMeetingCommand, OperationResult<Unit>>

    {
        private readonly DatabaseContext _context;
        private readonly IPersistence _persistence;

        public DeleteRestaurantMeetingCommandHandler(DatabaseContext context, IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteRestaurantMeetingCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var meeting =
                await _context.RestaurantMeetings.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);


            _context.RestaurantMeetings.Remove(meeting);

            var persistenceResult = await _persistence.SaveChangesAsync();
            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.CouldNotDelete);
            }

            result.Entity = Unit.Value;
            return result;
        }

    }
}
