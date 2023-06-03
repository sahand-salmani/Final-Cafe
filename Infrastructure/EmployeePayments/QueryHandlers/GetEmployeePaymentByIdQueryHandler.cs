using System.Collections.Generic;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.EmployeePayments.Queries;
using Infrastructure.EmployeePayments.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.EmployeePayments.QueryHandlers
{
    public class GetEmployeePaymentByIdQueryHandler : IRequestHandler<GetEmployeePaymentByIdQuery, GetEmployeePaymentVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetEmployeePaymentByIdQueryHandler(DatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetEmployeePaymentVm> Handle(GetEmployeePaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var empPayments = await _context.EmployeePayments.AsNoTracking().Include(e => e.Employee).
                SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if(empPayments == null)
            {
                return null;
            }

            return _mapper.Map<GetEmployeePaymentVm>(empPayments); 
        }
    }
}
