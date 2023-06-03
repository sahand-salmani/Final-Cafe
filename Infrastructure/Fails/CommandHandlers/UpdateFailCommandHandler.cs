using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Fails.Commands;
using Infrastructure.Fails.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Fails.CommandHandlers
{
    public class UpdateFailCommandHandler : IRequestHandler<UpdateFailCommand, OperationResult<GetFailsVm>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public UpdateFailCommandHandler(DatabaseContext context,
                                        IMapper mapper,
                                        IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<GetFailsVm>> Handle(UpdateFailCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetFailsVm>();

            if (request.Id != request.Model.Id)
            {
                return result.AddError(ErrorMessages.SourceCodeChange);
            }

            var fail = await _context.Fails.AsNoTracking().FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (fail is null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            var updated = _mapper.Map<Fail>(request.Model);

            _context.Fails.Update(updated);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = _mapper.Map<GetFailsVm>(updated);
            return result;
        }
    }
}
