using AutoMapper;
using DataAccess.Database;
using Infrastructure.PrePayments.Queries;
using Infrastructure.PrePayments.ViewModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.PrePayments.QueryHandlers
{
    public class GetPrePaymentToUpdateQueryHandler : IRequestHandler<GetPrePaymentToUpdateQuery, EditPrePaymentVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetPrePaymentToUpdateQueryHandler(DatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<EditPrePaymentVm> Handle(GetPrePaymentToUpdateQuery request, CancellationToken cancellationToken)
        {
            var prePayment = await _context.PrePayments.AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (prePayment is null)
            {
                return null;
            }

            return _mapper.Map<EditPrePaymentVm>(prePayment);
        }
    }
}
