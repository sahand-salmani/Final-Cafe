using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.EmployeePayments.Queries;
using Infrastructure.EmployeePayments.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EmployeePayments.QueryHandlers
{
    public class GetEmployeePaymentToUpdateQueryHandler : IRequestHandler<GetEmployeePaymentToUpdateQuery, UpdateEmployeePaymentVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetEmployeePaymentToUpdateQueryHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UpdateEmployeePaymentVm> Handle(GetEmployeePaymentToUpdateQuery request, CancellationToken cancellationToken)
        {
            var employeePayment = await _context.EmployeePayments.Include(e => e.Employee).AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (employeePayment is null)
            {
                return null;
            }

            return _mapper.Map<UpdateEmployeePaymentVm>(employeePayment);
        }
    }
}
