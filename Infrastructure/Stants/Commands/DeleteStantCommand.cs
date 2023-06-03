using Infrastructure.Common;
using MediatR;

namespace Infrastructure.Stants.Commands
{
    public class DeleteStantCommand : IRequest<OperationResult<Unit>>
    {
        public DeleteStantCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
