using System.Collections.Generic;
using Infrastructure.Roles.ViewModels;
using MediatR;

namespace Infrastructure.Roles.Queries
{
    public class GetAllRolesQuery : IRequest<List<GetRoleVm>>
    {
    }
}
