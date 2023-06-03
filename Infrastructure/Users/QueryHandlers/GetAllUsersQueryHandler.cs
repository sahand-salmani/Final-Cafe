using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Users;
using Infrastructure.Users.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Users.QueryHandlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PaginatedList<ApplicationUser>>
    {
        private readonly DatabaseContext _context;

        public GetAllUsersQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<ApplicationUser>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _context.Users.Include(e => e.Roles).ThenInclude(e => e.Role).OrderBy(e => e.UserName)
                .AsNoTracking();

            return await PaginatedList<ApplicationUser>.CreateAsync(users, request.Page, request.Size);
        }
    }
}
