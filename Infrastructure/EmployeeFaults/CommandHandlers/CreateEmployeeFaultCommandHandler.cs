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
    public class CreateEmployeeFaultCommandHandler : IRequestHandler<CreateEmployeeFaultCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CreateEmployeeFaultCommandHandler(DatabaseContext context,
                                                 IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OperationResult<int>> Handle(CreateEmployeeFaultCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var employee = await _context.Employees.AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Model.EmployeeId, cancellationToken);


            if (employee is null)
            {
                return result.AddError("Employee was not found");
            }

            var newFault = _mapper.Map<EmployeeFault>(request.Model);

            await _context.EmployeeFaults.AddAsync(newFault, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            result.Entity = employee.Id;
            return result;
        }
    }
}
