using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using Infrastructure.Roles.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Roles.QueryHandlers
{
    public class CheckRoleNameExistsQueryHandler : IRequestHandler<CheckRoleNameExistsQuery, bool>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public CheckRoleNameExistsQueryHandler(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<bool> Handle(CheckRoleNameExistsQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.RoleName))
            {
                return false;
            }

            return await _roleManager.RoleExistsAsync(request.RoleName);
        }
    }
}
