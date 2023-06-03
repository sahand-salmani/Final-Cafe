using Infrastructure.Common;
using MediatR;

namespace Infrastructure.Interns.Commands
{
    public class DeleteInternCommand : IRequest<OperationResult<Unit>>
    {
        public int Id { get; set; }

        public DeleteInternCommand(int id)
        {
            Id = id;
        }

    }
}
