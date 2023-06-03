using Infrastructure.Common;
using MediatR;

namespace Infrastructure.Fails.Commands
{
    public class DeleteFailCommand : IRequest<OperationResult<Unit>>
    {
        public DeleteFailCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
