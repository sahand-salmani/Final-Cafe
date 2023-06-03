using DataAccess.Pagination;
using Domain.Users;
using MediatR;

namespace Infrastructure.Users.Queries
{
    public class GetAllUsersQuery : IRequest<PaginatedList<ApplicationUser>>
    {
        public GetAllUsersQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
