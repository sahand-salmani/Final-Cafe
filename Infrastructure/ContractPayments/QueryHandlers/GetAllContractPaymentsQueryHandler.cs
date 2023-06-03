using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.ContractPayments.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ContractPayments.QueryHandlers
{
    public class GetAllContractPaymentsQueryHandler : IRequestHandler<GetAllContractPaymentsQuery, PaginatedList<ContractPayment>>
    {
        private readonly DatabaseContext _context;

        public GetAllContractPaymentsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<ContractPayment>> Handle(GetAllContractPaymentsQuery request, CancellationToken cancellationToken)
        {
            var cp = _context.ContractPayments.Include(e => e.Contract).ThenInclude(e => e.Restaurant).OrderByDescending(e => e.PaidAt).AsNoTracking();

            return await PaginatedList<ContractPayment>.CreateAsync(cp, request.Page, request.Size);
        }
    }
}
