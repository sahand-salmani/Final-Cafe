using Infrastructure.Common;
using MediatR;
using Infrastructure.PrePayments.ViewModels;

namespace Infrastructure.PrePayments.Commands
{
    public class CreatePrePaymentCommand : IRequest<OperationResult<int>>
    {
        public CreatePrePaymentCommand(CreatePrePaymentVm model)
        {
            Model = model;
        }
        public CreatePrePaymentVm Model { get; set; }
    }
}
