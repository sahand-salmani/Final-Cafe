using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.PrePayments.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.PrePayments.CommandHandlers
{
    public class CreatePrePaymentCommandHandler : IRequestHandler<CreatePrePaymentCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreatePrePaymentCommandHandler(DatabaseContext context, IMapper mapper, IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<int>> Handle(CreatePrePaymentCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var prepayment = _mapper.Map<PrePayment>(request.Model);

            await _context.PrePayments.AddAsync(prepayment, cancellationToken);

            var persistence = await _persistence.SaveChangesAsync();

            if (persistence == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            return result;
        }

    }
}
