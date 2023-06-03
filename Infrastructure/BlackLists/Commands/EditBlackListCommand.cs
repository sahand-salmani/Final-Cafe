using Infrastructure.BlackLists.ViewModels;
using Infrastructure.Common;
using MediatR;

namespace Infrastructure.BlackLists.Commands
{
    public class EditBlackListCommand : IRequest<OperationResult<int>>
    {
        public EditBlackListCommand(EditBlackListVm model)
        {
            Model = model;
        }

        public EditBlackListVm Model { get; set; }
    }
}
