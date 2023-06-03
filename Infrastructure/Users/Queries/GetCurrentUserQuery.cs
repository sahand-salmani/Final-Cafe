using Infrastructure.Users.ViewModels;
using MediatR;

namespace Infrastructure.Users.Queries
{
    public class GetCurrentUserQuery : IRequest<GetUserVm>
    {
    }
}
