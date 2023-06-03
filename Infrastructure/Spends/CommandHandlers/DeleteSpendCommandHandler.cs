using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.Spends.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Spends.CommandHandlers
{
    public class DeleteSpendCommandHandler : IRequestHandler<DeleteSpendCommand,OperationResult<Unit>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public DeleteSpendCommandHandler(DatabaseContext context,IMapper mapper,IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteSpendCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();
            var spend = await _context.Spends.SingleOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
            if(spend is null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            _context.Spends.Remove(spend);

            var persistence = await _persistence.SaveChangesAsync();

            if(persistence == 0)
            {
                return result.AddError(ErrorMessages.CouldNotDelete);
            }

            result.Entity = Unit.Value;

            return result;
        }
    }
}
