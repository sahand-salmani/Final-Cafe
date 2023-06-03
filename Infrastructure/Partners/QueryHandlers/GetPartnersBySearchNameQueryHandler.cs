using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Partners.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Partners.QueryHandlers
{
    public class GetPartnersBySearchNameQueryHandler : IRequestHandler<GetPartnersBySearchNameQuery, PaginatedList<Partner>>
    {
        private readonly DatabaseContext _context;

        public GetPartnersBySearchNameQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Partner>> Handle(GetPartnersBySearchNameQuery request, CancellationToken cancellationToken)
        {
            var partners = _context
                .Partners
                .Where(p => EF.Functions.Like(p.Name, $"%{request.Name}%"))
                .AsNoTracking()
                .OrderByDescending(e => e.CreatedAt);

            return await PaginatedList<Partner>.CreateAsync(partners, request.Page, request.Size);
        }
    }
}
