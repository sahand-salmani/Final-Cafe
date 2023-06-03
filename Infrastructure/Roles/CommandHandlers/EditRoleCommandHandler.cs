using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Users;
using Infrastructure.Common;
using Infrastructure.Roles.Commands;
using Infrastructure.Roles.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Roles.CommandHandlers
{
    public class EditRoleCommandHandler : IRequestHandler<EditRoleCommand, OperationResult<GetRoleVm>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public EditRoleCommandHandler(RoleManager<ApplicationRole> roleManager,
                                      IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<OperationResult<GetRoleVm>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetRoleVm>();
            var role = await _roleManager.FindByNameAsync(request.Name);
            if (role is null)
            {
                return result.AddError("Could not find specified role");
            }

            role.Name = request.Name;
            var identityResult = await _roleManager.UpdateAsync(role);
            if (!identityResult.Succeeded)
            {
                return result.AddError(identityResult.Errors.Select(e => e.Description).ToList());
            }

            result.Entity = _mapper.Map<GetRoleVm>(role);

            return result;
        }
    }
}
