using Infrastructure.Common;
using Infrastructure.ContractPayments.ViewModels;
using MediatR;

namespace Infrastructure.ContractPayments.Commands
{
    public class UpdateContractPaymentCommand : IRequest<OperationResult<GetContractPaymentVm>>
    {
        public UpdateContractPaymentCommand(UpdateContractPaymentVm model)
        {
            Model = model;
        }
        public UpdateContractPaymentVm Model { get; set; }
    }
}
