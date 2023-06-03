using Infrastructure.Common;
using Infrastructure.Spends.ViewModels;
using MediatR;

namespace Infrastructure.Spends.Commands
{
    public class CreateSpendCommand : IRequest<OperationResult<int>>
    {
        public CreateSpendCommand(CreateSpendVm model)
        {
            Model = model;
        }
        public CreateSpendVm Model { get; set; }
    }
}
