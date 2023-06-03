using Infrastructure.Common;
using MediatR;

namespace Infrastructure.Positions.Commands
{
    public class DeletePositionCommand : IRequest<OperationResult<Unit>>
    {
        public DeletePositionCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
