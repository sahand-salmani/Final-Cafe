using Infrastructure.Common;
using MediatR;

namespace Infrastructure.BlackLists.Commands
{
    public class DeleteBlackListCommand : IRequest<OperationResult<Unit>>
    {
        public DeleteBlackListCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
