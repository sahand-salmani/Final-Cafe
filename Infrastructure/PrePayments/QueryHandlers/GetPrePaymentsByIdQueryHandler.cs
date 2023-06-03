using AutoMapper;
using DataAccess.Database;
using Infrastructure.PrePayments.Queries;
using Infrastructure.PrePayments.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.PrePayments.QueryHandlers
{
    public class GetPrePaymentsByIdQueryHandler : IRequestHandler<GetPrePaymentsByIdQuery, GetPrePaymentVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetPrePaymentsByIdQueryHandler(DatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetPrePaymentVm> Handle(GetPrePaymentsByIdQuery request, CancellationToken cancellationToken)
        {
            var prepayment = await _context.PrePayments.AsNoTracking().Include(e => e.Employee).SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (prepayment is null)
            {
                return null;
            }

            GetPrePaymentVm result = _mapper.Map<GetPrePaymentVm>(prepayment);
            return result;
        }
    }
}
