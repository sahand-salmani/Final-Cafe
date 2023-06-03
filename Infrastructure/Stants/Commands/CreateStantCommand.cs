using Infrastructure.Common;
using Infrastructure.Stants.ViewModels;
using MediatR;

namespace Infrastructure.Stants.Commands
{
    public class CreateStantCommand : IRequest<OperationResult<int>>
    {
        public CreateStantCommand(CreateStantVm model)
        {
            Model = model;
        }
        public CreateStantVm Model { get; set; }
    }
}
