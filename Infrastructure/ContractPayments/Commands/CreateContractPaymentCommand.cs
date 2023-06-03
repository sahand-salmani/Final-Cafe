using Infrastructure.Common;
using Infrastructure.ContractPayments.ViewModels;
using MediatR;

namespace Infrastructure.ContractPayments.Commands
{
    public class CreateContractPaymentCommand : IRequest<OperationResult<int>>
    {
        public CreateContractPaymentCommand(CreateContractPaymentVm model)
        {
            Model = model;
        }
        public CreateContractPaymentVm Model { get; set; }
    }
}
