using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Interns.Commands;
using Infrastructure.Interns.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interns.CommandHandlers
{
    public class UpdateInternCommandHandler : IRequestHandler<UpdateInternCommand, OperationResult<GetInternVm>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public UpdateInternCommandHandler(DatabaseContext context,
                                          IMapper mapper,
                                          IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<GetInternVm>> Handle(UpdateInternCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetInternVm>();

            if (request.Id != request.GetInternVm.Id)
            {
                return result.AddError(ErrorMessages.SourceCodeChange);
            }

            var intern = await _context.Interns.AsNoTracking().SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (intern is null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            var updated = _mapper.Map<Intern>(request.GetInternVm);
            _context.Interns.Update(updated);

            var persistenceResult = await _persistence.SaveChangesAsync();
            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = _mapper.Map<GetInternVm>(updated);
            return result;
        }
    }
}
