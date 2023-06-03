using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Employees.Commands;
using Infrastructure.Employees.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Employees.CommandHandlers
{
    public class EditEmployeeCommandHandler : IRequestHandler<EditEmployeeCommand, OperationResult<GetEmployeeVm>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public EditEmployeeCommandHandler(DatabaseContext context,
                                          IMapper mapper,
                                          IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<GetEmployeeVm>> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetEmployeeVm>();
            if (request.Id != request.Model.Id)
            {
                return result.AddError(ErrorMessages.SourceCodeChange);
            }

            var position =
                await _context.Positions.FirstOrDefaultAsync(e => e.Id == request.Model.PositionId, cancellationToken);

            if (position is null)
            {
                return result.AddError("Position was not found");
            }

            var updatedEmployee = _mapper.Map<Employee>(request.Model);

            _context.Employees.Update(updatedEmployee);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = _mapper.Map<GetEmployeeVm>(updatedEmployee);

            return result;
        }
    }
}
