using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Roles.Queries
{
    public class GetUserRolesQuery : IRequest<MultiSelectList>
    {
        public GetUserRolesQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
