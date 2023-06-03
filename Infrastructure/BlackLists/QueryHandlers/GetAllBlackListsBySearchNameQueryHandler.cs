using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.BlackLists.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.BlackLists.QueryHandlers
{
    public class GetAllBlackListsBySearchNameQueryHandler : IRequestHandler<GetAllBlackListsBySearchNameQuery, PaginatedList<BlackList>>
    {
        private readonly DatabaseContext _context;

        public GetAllBlackListsBySearchNameQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<BlackList>> Handle(GetAllBlackListsBySearchNameQuery request, CancellationToken cancellationToken)
        {
            var bl = _context.BlackLists
                .AsNoTracking()
                .Where(e => EF.Functions.Like(e.Restaurant, $"%{request.Name}%"))
                .OrderByDescending(b => b.CreatedAt);

            return await PaginatedList<BlackList>.CreateAsync(bl, request.Page, request.Size);
        }
    }
}
