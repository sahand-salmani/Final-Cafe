using Infrastructure.Roles.ViewModels;
using MediatR;

namespace Infrastructure.Roles.Queries
{
    public class GetRoleToUpdateQuery : IRequest<UpdateRoleVm>
    {
        public GetRoleToUpdateQuery(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
