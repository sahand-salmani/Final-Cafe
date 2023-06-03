using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.EmployeePayments.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EmployeePayments.QueryHandlers
{
    public class GetPaymentsOfEmployeeQueryHandler : IRequestHandler<GetPaymentsOfEmployeeQuery, PaginatedList<EmployeePayment>>
    {
        private readonly DatabaseContext _context;

        public GetPaymentsOfEmployeeQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<EmployeePayment>> Handle(GetPaymentsOfEmployeeQuery request, CancellationToken cancellationToken)
        {
            var payments = _context.EmployeePayments
                .AsNoTracking()
                .Include(e => e.Employee)
                .Where(e => e.EmployeeId == request.Id)
                .OrderByDescending(e => e.PaidTime);

            return await PaginatedList<EmployeePayment>.CreateAsync(payments, request.Page, request.Size);
        }
    }
}
