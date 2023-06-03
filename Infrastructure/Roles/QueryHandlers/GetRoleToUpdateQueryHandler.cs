using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Users;
using Infrastructure.Roles.Queries;
using Infrastructure.Roles.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Roles.QueryHandlers
{
    public class GetRoleToUpdateQueryHandler : IRequestHandler<GetRoleToUpdateQuery, UpdateRoleVm>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public GetRoleToUpdateQueryHandler(RoleManager<ApplicationRole> roleManager,
                                           IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<UpdateRoleVm> Handle(GetRoleToUpdateQuery request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByNameAsync(request.Name);

            if (role is null)
            {
                return null;
            }

            return _mapper.Map<UpdateRoleVm>(role);
        }
    }
}
