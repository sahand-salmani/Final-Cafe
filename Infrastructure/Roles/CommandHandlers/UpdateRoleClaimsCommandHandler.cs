using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Domain.Users;
using Infrastructure.Common;
using Infrastructure.Roles.Commands;
using Infrastructure.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Roles.CommandHandlers
{
    public class UpdateRoleClaimsCommandHandler : IRequestHandler<UpdateRoleClaimsCommand, OperationResult<string>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly DatabaseContext _context;
        private readonly UserManager<ApplicationUser> _usersManager;
        private readonly IMediator _mediator;

        public UpdateRoleClaimsCommandHandler(RoleManager<ApplicationRole> roleManager,
                                              SignInManager<ApplicationUser> signInManager,
                                              DatabaseContext context,
                                              UserManager<ApplicationUser> usersManager,
                                              IMediator mediator)
        {
            _roleManager = roleManager;
            _context = context;
            _usersManager = usersManager;
            _mediator = mediator;
        }
        public async Task<OperationResult<string>> Handle(UpdateRoleClaimsCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<string>();

            var currentUser = await _mediator.Send(new GetCurrentUserQuery(), cancellationToken);

            if (currentUser is null)
            {
                return result.AddError("Something went wrong");
            }

            var user = await _usersManager.Users.Include(e => e.Roles).ThenInclude(e => e.Role)
                .FirstOrDefaultAsync(e => e.Id == currentUser.Id, cancellationToken);
            if (user is null)
            {
                return result.AddError("Something went wrong");
            }

            if (!(user.Roles.Any(e => e.Role.Name.ToUpper() == "ADMIN")))
            {
                return result.AddError("You do not have permission to change admin accesses!!");
            }


            var role = await _roleManager.FindByIdAsync(request.Model.RoleId);

            if (role is null)
            {
                return result.AddError("Role was not found");
            }

            var roleClaims = await _roleManager.GetClaimsAsync(role);

            if (roleClaims.Any())
            {
                foreach (var roleClaim in roleClaims)
                {
                    await _roleManager.RemoveClaimAsync(role, roleClaim);
                }
            }

            foreach (var claim in request.Model.ClaimsValues)
            {
                if (ClaimStore.Claims.Any(e => e.Value == claim))
                {
                    var tempClaim = new Claim(claim, claim);
                    await _roleManager.AddClaimAsync(role, tempClaim);
                }
            }


            var usersInRole = await _context.Users.Include(e => e.Roles)
                .Where(e => e.Roles.Any(q => q.RoleId == role.Id)).ToListAsync(cancellationToken);

            //if (usersInRole != null)
            //{
            //    foreach (var applicationUser in usersInRole)
            //    {
            //        await _usersManager.UpdateSecurityStampAsync(applicationUser);
            //    }
            //}


            result.Entity = role.Id;
            return result;
        }
    }
}
