using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Employees.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Employees.CommandHandlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateEmployeeCommandHandler(DatabaseContext context,
                                            IMapper mapper,
                                            IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<int>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var position =
                await _context.Positions.FirstOrDefaultAsync(e => e.Id == request.Model.PositionId, cancellationToken);
            if (position is null)
            {
                return result.AddError("Could not find the specified position");
            }

            var employee = _mapper.Map<Employee>(request.Model);

            await _context.Employees.AddAsync(employee, cancellationToken);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            result.Entity = employee.Id;
            return result;
        }
    }
}
