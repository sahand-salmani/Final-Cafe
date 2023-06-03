using Infrastructure.Common;
using Infrastructure.Contracts.ViewModels;
using MediatR;

namespace Infrastructure.Contracts.Commands
{
    public class CreateContractCommand : IRequest<OperationResult<int>>
    {
        public CreateContractCommand(CreateContractVm model)
        {
            Model = model;
        }

        public CreateContractVm Model { get; set; }
    }
}
