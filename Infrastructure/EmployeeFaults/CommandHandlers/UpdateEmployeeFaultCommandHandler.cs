using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.EmployeeFaults.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EmployeeFaults.CommandHandlers
{
    public class UpdateEmployeeFaultCommandHandler : IRequestHandler<UpdateEmployeeFaultCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public UpdateEmployeeFaultCommandHandler(DatabaseContext context,
                                                 IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OperationResult<int>> Handle(UpdateEmployeeFaultCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var ef = await _context.EmployeeFaults.AsNoTracking().SingleOrDefaultAsync(e => e.Id == request.Model.Id, cancellationToken);

            if (ef is null)
            {
                return result.AddError("Employee Fault was not found");
            }

            var emp = await _context.Employees.SingleOrDefaultAsync(e => e.Id == request.Model.EmployeeId, cancellationToken);
            if (emp is null)
            {
                return result.AddError("Employee was not found");
            }

            var updated = _mapper.Map<EmployeeFault>(request.Model);

            _context.EmployeeFaults.Update(updated);

            await _context.SaveChangesAsync(cancellationToken);


            result.Entity = emp.Id;

            return result;

        }
    }
}
