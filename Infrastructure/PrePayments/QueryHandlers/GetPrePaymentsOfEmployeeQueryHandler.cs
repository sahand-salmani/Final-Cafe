using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.PrePayments.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.PrePayments.QueryHandlers
{
    public class GetPrePaymentsOfEmployeeQueryHandler : IRequestHandler<GetPrePaymentsOfEmployeeQuery, PaginatedList<PrePayment>>
    {
        private readonly DatabaseContext _context;

        public GetPrePaymentsOfEmployeeQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<PrePayment>> Handle(GetPrePaymentsOfEmployeeQuery request, CancellationToken cancellationToken)
        {
            var prePayments = _context.PrePayments.Include(e => e.Employee).AsNoTracking().Where(e => e.EmployeeId == request.Id);

            return await PaginatedList<PrePayment>.CreateAsync(prePayments, request.Page, request.Size);
        }
    }
}
