using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Partners.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Partners.QueryHandlers
{
    public class GetAllPartnersQueryHandler : IRequestHandler<GetAllPartnersQuery, PaginatedList<Partner>>
    {
        private readonly DatabaseContext _context;

        public GetAllPartnersQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Partner>> Handle(GetAllPartnersQuery request, CancellationToken cancellationToken)
        {
            var partner = _context.Partners.AsNoTracking().OrderByDescending(e => e.CreatedAt);

            return await PaginatedList<Partner>.CreateAsync(partner, request.Page, request.Size);
        }
    }
}
