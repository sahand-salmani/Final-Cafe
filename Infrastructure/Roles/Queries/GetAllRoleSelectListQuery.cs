using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Roles.Queries
{
    public class GetAllRoleSelectListQuery : IRequest<MultiSelectList>
    {
    }
}
