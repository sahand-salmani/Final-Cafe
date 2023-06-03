using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using Infrastructure.Claims.Queries;
using Infrastructure.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Claims.QueryHandlers
{
    public class GetAllClaimsMultiSelectListQueryHandler : IRequestHandler<GetAllClaimsMultiSelectListQuery, MultiSelectList>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public GetAllClaimsMultiSelectListQueryHandler(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<MultiSelectList> Handle(GetAllClaimsMultiSelectListQuery request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.RoleId);
            var claims = await _roleManager.GetClaimsAsync(role);

            var selected = claims.Select(e => e.Type).ToList();

            if (claims.Any())
            {
                return new MultiSelectList(ClaimStore.Claims, nameof(Claim.Value), nameof(Claim.Type), selected); 
            }


            return new MultiSelectList(ClaimStore.Claims, nameof(Claim.Value), nameof(Claim.Type));

        }
    }
}
