using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.UserToken.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UserToken.QueryHandlers
{
    public class GetAllTokensQueryHandler : IRequestHandler<GetAllTokensQuery, PaginatedList<UserRegisterToken>>
    {
        private readonly DatabaseContext _context;

        public GetAllTokensQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<UserRegisterToken>> Handle(GetAllTokensQuery request, CancellationToken cancellationToken)
        {
            var tokens = _context.UserRegisterTokens.AsNoTracking().OrderByDescending(e => e.CreatedAt);

            return await PaginatedList<UserRegisterToken>.CreateAsync(tokens, request.Page, request.Size);
        }
    }
}
