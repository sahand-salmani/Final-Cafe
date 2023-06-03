using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Spends.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Spends.CommandHandlers
{
    public class CreateSpendCommandHandler : IRequestHandler<CreateSpendCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateSpendCommandHandler(DatabaseContext context,IMapper mapper,IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<int>> Handle(CreateSpendCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var spend = _mapper.Map<Spend>(request.Model);
            await _context.Spends.AddAsync(spend,cancellationToken);

            var persistence = await _persistence.SaveChangesAsync();

            if (persistence == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            result.Entity = spend.Id;

            return result;
        }
    }
}
