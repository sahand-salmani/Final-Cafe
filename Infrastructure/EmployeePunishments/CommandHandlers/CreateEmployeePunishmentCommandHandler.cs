using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.EmployeePunishments.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EmployeePunishments.CommandHandlers
{
    public class CreateEmployeePunishmentCommandHandler : IRequestHandler<CreateEmployeePunishmentCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CreateEmployeePunishmentCommandHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OperationResult<int>> Handle(CreateEmployeePunishmentCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var employee =
                await _context.Employees.SingleOrDefaultAsync(e => e.Id == request.Model.EmployeeId, cancellationToken);

            if (employee is null)
            {
                return result.AddError("Employee was not found");
            }

            var newPunishment = _mapper.Map<EmployeePunishment>(request.Model);

            await _context.EmployeePunishments.AddAsync(newPunishment, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            result.Entity = employee.Id;

            return result;
        }
    }
}
