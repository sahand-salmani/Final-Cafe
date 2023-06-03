using Infrastructure.Common;
using MediatR;

namespace Infrastructure.Users.Commands
{
    public class DeleteUserCommand : IRequest<OperationResult<Unit>>
    {
        public DeleteUserCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
