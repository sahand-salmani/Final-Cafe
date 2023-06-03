using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Infrastructure.Common;
using Infrastructure.EmployeePunishments.Commands;
using MediatR;

namespace Infrastructure.EmployeePunishments.CommandHandlers
{
    public class DeleteEmployeePunishmentCommandHandler : IRequestHandler<DeleteEmployeePunishmentCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;

        public DeleteEmployeePunishmentCommandHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<OperationResult<int>> Handle(DeleteEmployeePunishmentCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var p = await _context.EmployeePunishments.FindAsync(request.Id);

            if (p is null)
            {
                return result.AddError("Employee punishment was not found");
            }

            _context.EmployeePunishments.Remove(p);

            await _context.SaveChangesAsync(cancellationToken);

            result.Entity = p.EmployeeId;

            return result;
        }
    }
}
