using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Fails.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Fails.CommandHandlers
{
    public class CreateFailCommandHandler : IRequestHandler<CreateFailCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateFailCommandHandler(DatabaseContext context,
                                        IMapper mapper,
                                        IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<int>> Handle(CreateFailCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var employeeExists = await _context.Employees.AnyAsync(e =>e.Id ==  request.EmployeeId, cancellationToken);

            if (!employeeExists)
            {
                return result.AddError("Employee could not found");
            }

            var fail = _mapper.Map<Fail>(request);

            await _context.Fails.AddAsync(fail, cancellationToken);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            result.Entity = fail.Id;

            return result;
        }
    }
}
