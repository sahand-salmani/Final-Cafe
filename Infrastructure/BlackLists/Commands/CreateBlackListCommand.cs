using Infrastructure.BlackLists.ViewModels;
using Infrastructure.Common;
using MediatR;

namespace Infrastructure.BlackLists.Commands
{
    public class CreateBlackListCommand : IRequest<OperationResult<int>>
    {
        public CreateBlackListCommand(CreateBlackListVm model)
        {
            Model = model;
        }

        public CreateBlackListVm Model { get; set; }
    }
}
