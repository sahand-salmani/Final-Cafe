using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.RestaurantMeetings.Commands;
using MediatR;

namespace Infrastructure.RestaurantMeetings.CommandHandlers
{
    public class CreateMeetingQueryHandler : IRequestHandler<CreateMeetingQuery, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CreateMeetingQueryHandler(DatabaseContext context,
                                         IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OperationResult<int>> Handle(CreateMeetingQuery request, CancellationToken cancellationToken)
        {
            request.Model.HappensAt = request.Model.HappensAt.ToAzDateTime();

            var result = new OperationResult<int>();

            var newMeeting = _mapper.Map<RestaurantMeeting>(request.Model);

            newMeeting.RestaurantId = null;

            await _context.RestaurantMeetings.AddAsync(newMeeting, cancellationToken);

            var persistenceResult = await _context.SaveChangesAsync(cancellationToken);

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            result.Entity = newMeeting.Id;

            return result;
        }
    }
}
