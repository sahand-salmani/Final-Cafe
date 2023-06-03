using Infrastructure.Common;
using MediatR;

namespace Infrastructure.PrePayments.Commands
{
    public class DeletePrePaymentCommand : IRequest<OperationResult<Unit>>
    {
        public DeletePrePaymentCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
