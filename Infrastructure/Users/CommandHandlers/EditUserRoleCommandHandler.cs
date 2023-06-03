using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Domain.Users;
using Infrastructure.Common;
using Infrastructure.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Users.CommandHandlers
{
    public class EditUserRoleCommandHandler : IRequestHandler<EditUserRoleCommand, OperationResult<string>>
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public EditUserRoleCommandHandler(DatabaseContext context,
                                          UserManager<ApplicationUser> userManager,
                                          RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<OperationResult<string>> Handle(EditUserRoleCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<string>();
            
            var user = await _userManager.FindByIdAsync(request.Model.Id);

            if (user is null)
            {
                return result.AddError("User was not found");
            }

            if (request.Model.RoleId == null)
            {
                return result.AddError("Role was not selected");
            }

            if (!request.Model.RoleId.Any())
            {
                return result.AddError("Role was not selected");
            }

            var roles = await _context.Roles.Where(e => request.Model.RoleId.Contains(e.Id)).ToListAsync(cancellationToken);

            if (roles is null)
            {
                return result.AddError("Selected Roles was not found");
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var deleteResult = await _userManager.RemoveFromRolesAsync(user, userRoles);
            if (!deleteResult.Succeeded)
            {
                return result.AddError(deleteResult.Errors.Select(e => e.Description).ToList());
            }
            

            var addResult = await _userManager.AddToRolesAsync(user, roles.Select(e => e.Name));

            if (!addResult.Succeeded)
            {
                var reAddResult = await _userManager.AddToRolesAsync(user, userRoles);
                if (!reAddResult.Succeeded)
                {
                    return result.AddError("I do not know what happened");
                }
                return result.AddError("Could not add to the specified roles");
            }

            result.Entity = user.Id;
            return result;

        }
    }
}
