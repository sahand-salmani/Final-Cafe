using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.ContractPayments.Queries;
using Infrastructure.ContractPayments.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ContractPayments.QueryHandlers
{
    public class GetContractPaymentToUpdateQueryHandler : IRequestHandler<GetContractPaymentToUpdateQuery, UpdateContractPaymentVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetContractPaymentToUpdateQueryHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UpdateContractPaymentVm> Handle(GetContractPaymentToUpdateQuery request, CancellationToken cancellationToken)
        {
            var payment = await _context.ContractPayments.AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            return payment is null ? null : _mapper.Map<UpdateContractPaymentVm>(payment);
        }
    }
}
