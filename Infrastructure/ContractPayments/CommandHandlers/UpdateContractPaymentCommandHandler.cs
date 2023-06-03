using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.ContractPayments.Commands;
using Infrastructure.ContractPayments.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ContractPayments.CommandHandlers
{
    public class UpdateContractPaymentCommandHandler : IRequestHandler<UpdateContractPaymentCommand, OperationResult<GetContractPaymentVm>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public UpdateContractPaymentCommandHandler(DatabaseContext context,
                                                   IMapper mapper,
                                                   IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<GetContractPaymentVm>> Handle(UpdateContractPaymentCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetContractPaymentVm>();
            var cp = await _context.ContractPayments.AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Model.Id, cancellationToken);

            if (cp is null)
            {
                return result.AddError("Contract Payment was not found");
            }

            var updated = _mapper.Map<ContractPayment>(request.Model);

            _context.ContractPayments.Update(updated);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = _mapper.Map<GetContractPaymentVm>(updated);

            return result;
        }
    }
}
