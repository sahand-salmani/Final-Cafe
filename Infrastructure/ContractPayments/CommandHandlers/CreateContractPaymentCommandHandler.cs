using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.ContractPayments.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ContractPayments.CommandHandlers
{
    public class CreateContractPaymentCommandHandler : IRequestHandler<CreateContractPaymentCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateContractPaymentCommandHandler(DatabaseContext context,
                                                   IMapper mapper,
                                                   IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<int>> Handle(CreateContractPaymentCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var contractExists = await _context.Contracts.AsNoTracking()
                .AnyAsync(e => e.Id == request.Model.ContractId, cancellationToken);

            if (!contractExists)
            {
                return result.AddError("Contract was not found");
            }

            var newPayment = _mapper.Map<Domain.Models.ContractPayment>(request.Model);

            await _context.ContractPayments.AddAsync(newPayment, cancellationToken);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            result.Entity = newPayment.Id;
            return result;
        }
    }
}
