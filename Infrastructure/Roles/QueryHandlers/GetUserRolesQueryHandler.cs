using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Domain.Users;
using Infrastructure.Roles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Roles.QueryHandlers
{
    public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, MultiSelectList>
    {
        private readonly DatabaseContext _context;

        public GetUserRolesQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<MultiSelectList> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Include(e => e.Roles).SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
            var selectedRoles = user.Roles.Select(e => e.RoleId).ToList();


            var roles = await _context.Roles.ToListAsync(cancellationToken);

            if (!selectedRoles.Any())
            {
                return new MultiSelectList(roles, nameof(ApplicationRole.Id), nameof(ApplicationRole.Name));
            }

            return new MultiSelectList(roles, nameof(ApplicationRole.Id), nameof(ApplicationRole.Name), selectedRoles);

        }
    }
}
