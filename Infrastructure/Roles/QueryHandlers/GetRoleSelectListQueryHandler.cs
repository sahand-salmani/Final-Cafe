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
    public class GetRoleSelectListQueryHandler : IRequestHandler<GetRoleSelectListQuery, SelectList>
    {
        private readonly DatabaseContext _context;

        public GetRoleSelectListQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<SelectList> Handle(GetRoleSelectListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _context.Roles.ToListAsync(cancellationToken);

            return new SelectList(roles, nameof(ApplicationRole.Id), nameof(ApplicationRole.Name));
        }
    }
}
