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
    public class GetContractPaymentsQueryHandler : IRequestHandler<GetContractPaymentsQuery, PaginatedList<ContractPayment>>
    {
        private readonly DatabaseContext _context;

        public GetContractPaymentsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<ContractPayment>> Handle(GetContractPaymentsQuery request, CancellationToken cancellationToken)
        {
            var payments = _context.ContractPayments.Where(e => e.ContractId == request.Id)
                .Include(e => e.Contract).ThenInclude(e => e.Restaurant).OrderByDescending(e => e.PaidAt);

            return await PaginatedList<ContractPayment>.CreateAsync(payments, request.Page, request.Size);
        }
    }
}
