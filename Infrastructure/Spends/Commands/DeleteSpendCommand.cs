using Infrastructure.Common;
using MediatR;

namespace Infrastructure.Spends.Commands
{
    public class DeleteSpendCommand : IRequest<OperationResult<Unit>>
    {
        public DeleteSpendCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
