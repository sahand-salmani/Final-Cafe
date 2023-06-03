using Infrastructure.Common;
using Infrastructure.Fails.ViewModels;
using MediatR;

namespace Infrastructure.Fails.Commands
{
    public class UpdateFailCommand : IRequest<OperationResult<GetFailsVm>>
    {
        public UpdateFailCommand(int id, UpdateFailVm model)
        {
            Id = id;
            Model = model;
        }
        public int Id { get; set; }
        public UpdateFailVm Model { get; set; }
    }
}
