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
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, OperationResult<GetRoleVm>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(RoleManager<ApplicationRole> roleManager,
                                        IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<OperationResult<GetRoleVm>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetRoleVm>();

            var role = await _roleManager.FindByIdAsync(request.Model.Id);

            if (role is null)
            {
                return result.AddError("Role was not found");
            }

            role.Name = request.Model.Name;

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
