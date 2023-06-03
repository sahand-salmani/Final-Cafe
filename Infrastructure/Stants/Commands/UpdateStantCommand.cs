using Infrastructure.Common;
using Infrastructure.Stants.ViewModels;
using MediatR;

namespace Infrastructure.Stants.Commands
{
    public class UpdateStantCommand : IRequest<OperationResult<GetStantVm>>
    {
        public UpdateStantCommand(int id,UpdateStantVm model)
        {
            Id = id;
            Model = model;
        }
        public int Id { get; set; }
        public UpdateStantVm Model { get; set; }
    }
}
