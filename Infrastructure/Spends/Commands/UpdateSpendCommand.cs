using Infrastructure.Common;
using Infrastructure.Spends.ViewModels;
using MediatR;

namespace Infrastructure.Spends.Commands
{
    public class UpdateSpendCommand : IRequest<OperationResult<GetSpendVm>>
    {
        public UpdateSpendCommand(int id,EditSpendVm model)
        {
            Model = model;
            Id = id;
        }
        public int Id { get; set; }
        public EditSpendVm Model { get; set; }
    }
}
