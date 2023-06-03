using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Domain.Users;
using Infrastructure.Common;
using Infrastructure.Roles.Commands;
using Infrastructure.Roles.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Roles.CommandHandlers
{
    public class AddNewRoleCommandHandler : IRequestHandler<AddNewRoleCommand, OperationResult<GetRoleVm>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public AddNewRoleCommandHandler(RoleManager<ApplicationRole> roleManager,
                                        DatabaseContext context,
                                        IMapper mapper)
        {
            _roleManager = roleManager;
            _context = context;
            _mapper = mapper;
        }
        public async Task<OperationResult<GetRoleVm>> Handle(AddNewRoleCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetRoleVm>();
            var roleExists = await _roleManager.RoleExistsAsync(request.RoleName);

            if (roleExists)
            {
                return null;
            }

            var role = new ApplicationRole()
            {
                Name = request.RoleName,
                Rank = 2,
            };

            IdentityResult addResult = await _roleManager.CreateAsync(role);

            if (!addResult.Succeeded)
            {
                return result.AddError(addResult.Errors.Select(e => e.Description).ToList());
            }

            var getRole = await _context.Roles.Include(e => e.Users).ThenInclude(e => e.User)
                .SingleOrDefaultAsync(e => e.Name == role.Name, cancellationToken);

            result.Entity = _mapper.Map<GetRoleVm>(getRole);

            return result;
        }
    }
}
