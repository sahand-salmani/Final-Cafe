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
    public class CreateUserWithTokenCommandHandler : IRequestHandler<CreateUserWithTokenCommand, OperationResult<string>>
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateUserWithTokenCommandHandler(DatabaseContext context,
                                                 UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<OperationResult<string>> Handle(CreateUserWithTokenCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<string>();

            var token = await _context.UserRegisterTokens.SingleOrDefaultAsync(e => e.Token == request.Model.Token, cancellationToken);

            if (token is null)
            {
                return result.AddError("Invalid token");
            }

            if (token.IsUsed)
            {
                return result.AddError("Token has been used");
            }

            var role = await _context.Roles.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == token.RoleId, cancellationToken);

            if (role is null)
            {
                return result.AddError("Invalid token");
            }


            var userNameExists = await _userManager.FindByNameAsync(request.Model.UserName);

            if (userNameExists != null)
            {
                return result.AddError("This user name is already taken");
            }

            var newUser = new ApplicationUser()
            {
                UserName = request.Model.UserName,
                NormalizedUserName = request.Model.UserName.ToUpper(),
                Email = request.Model.Email.ToUpper(),
            };

            var identityResult = await _userManager.CreateAsync(newUser, request.Model.Password);

            if (!identityResult.Succeeded)
            {
                return result.AddError(identityResult.Errors.Select(e => e.Description).ToList());
            }

            await _context.SaveChangesAsync(cancellationToken);

            await _userManager.AddToRoleAsync(newUser, role.Name);

            token.IsUsed = true;
            _context.UserRegisterTokens.Update(token);
            await _context.SaveChangesAsync(cancellationToken);

            result.Entity = newUser.Id;
            return result;

        }
    }
}
