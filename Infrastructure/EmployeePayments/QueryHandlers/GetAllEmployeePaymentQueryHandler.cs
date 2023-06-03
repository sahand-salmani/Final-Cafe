using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.EmployeePayments.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.EmployeePayments.QueryHandlers
{
    public class GetAllEmployeePaymentQueryHandler : IRequestHandler<GetAllEmployeePaymentsQuery, PaginatedList<EmployeePayment>>
    {
        private readonly DatabaseContext _context;

        public GetAllEmployeePaymentQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<EmployeePayment>> Handle(GetAllEmployeePaymentsQuery request, CancellationToken cancellationToken)
        {
            var empPayments = _context.EmployeePayments.AsNoTracking().Include(e => e.Employee)
                .OrderByDescending(p => p.CreatedAt);

            return await PaginatedList<EmployeePayment>.CreateAsync(empPayments, request.Page, request.Size);
        }
    }
}
