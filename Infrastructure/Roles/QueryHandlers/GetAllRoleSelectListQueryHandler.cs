using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using Infrastructure.Roles.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Roles.QueryHandlers
{
    public class GetAllRoleSelectListQueryHandler : IRequestHandler<GetAllRoleSelectListQuery, MultiSelectList>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public GetAllRoleSelectListQueryHandler(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<MultiSelectList> Handle(GetAllRoleSelectListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleManager.Roles.AsNoTracking().ToListAsync(cancellationToken);

            return new MultiSelectList(roles, nameof(ApplicationRole.Id), nameof(ApplicationRole.Name));
        }
    }
}
