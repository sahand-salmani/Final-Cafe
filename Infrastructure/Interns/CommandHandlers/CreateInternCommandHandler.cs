using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Interns.Commands;
using MediatR;

namespace Infrastructure.Interns.CommandHandlers
{
    public class CreateInternCommandHandler : IRequestHandler<CreateInternCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _dbContext;
        private readonly IPersistence _persistence;
        private readonly IMapper _mapper;

        public CreateInternCommandHandler(DatabaseContext dbContext, 
                                          IPersistence persistence,
                                          IMapper mapper)
        {
            _dbContext = dbContext;
            _persistence = persistence;
            _mapper = mapper;
        }


        public async Task<OperationResult<int>> Handle(CreateInternCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var intern = _mapper.Map<Intern>(request);

            await _dbContext.Interns.AddAsync(intern, cancellationToken);

            var persistence = await _persistence.SaveChangesAsync();

            if (persistence > 0)
            {
                result.Entity = intern.Id;
                return result;
            }

            return result.AddError(ErrorMessages.CouldNotAddToDatabase);
        }
    }
}
