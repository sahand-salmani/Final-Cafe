using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.EmployeePayments.Commands;
using Infrastructure.EmployeePayments.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EmployeePayments.CommandHandlers
{
    public class UpdateEmployeePaymentCommandHandler : IRequestHandler<UpdateEmployeePaymentCommand, OperationResult<GetEmployeePaymentVm>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public UpdateEmployeePaymentCommandHandler(DatabaseContext context, IMapper mapper, IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<GetEmployeePaymentVm>> Handle(UpdateEmployeePaymentCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetEmployeePaymentVm>();

            var employeeExists = await _context.Employees.AnyAsync(e => e.Id == request.Model.EmployeeId, cancellationToken);

            if (!employeeExists)
            {
                return result.AddError("Employee was not found");
            }

            var paymentExists = await _context.EmployeePayments.AsNoTracking().AnyAsync(e => e.Id == request.Id, cancellationToken);

            if (!paymentExists)
            {
                return result.AddError("Payment was not found");
            }

            var updated = _mapper.Map<EmployeePayment>(request.Model);

            _context.EmployeePayments.Update(updated);

            var persistenceResult = await _persistence.SaveChangesAsync();
            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = _mapper.Map<GetEmployeePaymentVm>(updated);

            return result;
        }
    }
}
