using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.EmployeeFaults.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EmployeeFaults.QueryHandlers
{
    public class GetFaultsOfEmployeeQueryHandler : IRequestHandler<GetFaultsOfEmployeeQuery, PaginatedList<EmployeeFault>>
    {
        private readonly DatabaseContext _context;

        public GetFaultsOfEmployeeQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<EmployeeFault>> Handle(GetFaultsOfEmployeeQuery request, CancellationToken cancellationToken)
        {
            var ef = _context.EmployeeFaults.Include(e => e.Employee).AsNoTracking().Where(e => e.EmployeeId == request.Id)
                .OrderByDescending(e => e.DateTime);

            return await PaginatedList<EmployeeFault>.CreateAsync(ef, request.Page, request.Size);
        }
    }
}
