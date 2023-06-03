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
    public class UpdateEmployeePunishmentCommandHandler : IRequestHandler<UpdateEmployeePunishmentCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public UpdateEmployeePunishmentCommandHandler(DatabaseContext context,
                                                      IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OperationResult<int>> Handle(UpdateEmployeePunishmentCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var p = await _context.EmployeePunishments.AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Model.Id, cancellationToken);

            if (p is null)
            {
                return result.AddError("Employee punishment was not found");
            }

            var updated = _mapper.Map<EmployeePunishment>(request.Model);

            _context.EmployeePunishments.Update(updated);

            await _context.SaveChangesAsync(cancellationToken);

            result.Entity = updated.EmployeeId;

            return result;
        }
    }
}
