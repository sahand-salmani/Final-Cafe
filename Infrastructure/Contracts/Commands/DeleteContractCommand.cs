using Infrastructure.Common;
using MediatR;

namespace Infrastructure.Contracts.Commands
{
    public class DeleteContractCommand : IRequest<OperationResult<Unit>>
    {
        public DeleteContractCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
