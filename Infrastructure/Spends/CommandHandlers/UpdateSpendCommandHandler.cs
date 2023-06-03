using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Spends.Commands;
using Infrastructure.Spends.ViewModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Spends.CommandHandlers
{
    public class UpdateSpendCommandHandler : IRequestHandler<UpdateSpendCommand, OperationResult<GetSpendVm>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public UpdateSpendCommandHandler(DatabaseContext context,IMapper mapper,IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<GetSpendVm>> Handle(UpdateSpendCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetSpendVm>();
            if(request.Id != request.Model.Id)
            {
                return result.AddError(ErrorMessages.SourceCodeChange);
            }

            var updateSpend = _mapper.Map<Spend>(request.Model);
            _context.Update(updateSpend);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if(persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }
            result.Entity = _mapper.Map<GetSpendVm>(updateSpend);

            return result;
        }
    }
}
