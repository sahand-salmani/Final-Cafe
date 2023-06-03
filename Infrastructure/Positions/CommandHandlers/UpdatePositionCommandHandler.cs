using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Positions.Commands;
using Infrastructure.Positions.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Positions.CommandHandlers
{
    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, OperationResult<GetPositionVm>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public UpdatePositionCommandHandler(DatabaseContext context,
                                            IMapper mapper,
                                            IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<GetPositionVm>> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetPositionVm>();

            if (request.Id != request.Model.Id)
            {
                return result.AddError(ErrorMessages.SourceCodeChange);
            }


            var position = await _context.Positions.AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (position is null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            var updated = _mapper.Map<Position>(request.Model);

            _context.Positions.Update(updated);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = _mapper.Map<GetPositionVm>(updated);
            return result;
        }
    }
}
