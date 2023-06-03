using Infrastructure.Users.ViewModels;
using MediatR;

namespace Infrastructure.Users.Queries
{
    public class GetUserToUpdateQuery : IRequest<EditUserRoleVm>
    {
        public GetUserToUpdateQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
