using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.PrePayments.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.PrePayments.QueryHandlers
{
    public class GetAllPrePaymentsQueryHandler : IRequestHandler<GetAllPrePaymentsQuery, PaginatedList<PrePayment>>
    {
        private readonly DatabaseContext _context;

        public GetAllPrePaymentsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<PrePayment>> Handle(GetAllPrePaymentsQuery request, CancellationToken cancellationToken)
        {
            var prePayments = _context.PrePayments
                .AsNoTracking()
                .Include(c=>c.Employee)
                .OrderByDescending(c=>c.CreatedAt);

            return await PaginatedList<PrePayment>.CreateAsync(prePayments, request.Page, request.Size);
        }
    }
}
