using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.PrePayments.Commands;
using Infrastructure.PrePayments.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.PrePayments.CommandHandlers
{
    public class EditPrePaymentCommandHandler : IRequestHandler<EditPrePaymentCommand, OperationResult<GetPrePaymentVm>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public EditPrePaymentCommandHandler(DatabaseContext context,IMapper mapper,IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<GetPrePaymentVm>> Handle(EditPrePaymentCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetPrePaymentVm>();

            if (request.Id != request.Model.Id)
            {
                return result.AddError(ErrorMessages.SourceCodeChange);
            }

            var payment =
                await _context.Employees.AsNoTracking().SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (payment is null)
            {
                return result.AddError("Employe was not found");
            }

            var updatedPrepayment = _mapper.Map<PrePayment>(request.Model);

            _context.PrePayments.Update(updatedPrepayment);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = _mapper.Map<GetPrePaymentVm>(updatedPrepayment);

            return result;
        }
    }
}
