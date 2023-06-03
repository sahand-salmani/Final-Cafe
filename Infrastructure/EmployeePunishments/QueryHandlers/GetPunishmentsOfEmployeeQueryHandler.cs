using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.EmployeePunishments.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EmployeePunishments.QueryHandlers
{
    public class GetPunishmentsOfEmployeeQueryHandler : IRequestHandler<GetPunishmentsOfEmployeeQuery, PaginatedList<EmployeePunishment>>
    {
        private readonly DatabaseContext _context;

        public GetPunishmentsOfEmployeeQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<EmployeePunishment>> Handle(GetPunishmentsOfEmployeeQuery request, CancellationToken cancellationToken)
        {
            var ps = _context.EmployeePunishments.Include(e => e.Employee).AsNoTracking().Where(e => e.EmployeeId == request.Id)
                .OrderByDescending(e => e.At);
            return await PaginatedList<EmployeePunishment>.CreateAsync(ps, request.Page, request.Size);
        }
    }
}
