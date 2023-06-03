using Infrastructure.Common;
using Infrastructure.Positions.ViewModels;
using MediatR;

namespace Infrastructure.Positions.Commands
{
    public class UpdatePositionCommand : IRequest<OperationResult<GetPositionVm>>
    {
        public UpdatePositionCommand(int id, GetPositionVm model)
        {
            Id = id;
            Model = model;
        }
        public int Id { get; set; }
        public GetPositionVm Model { get; set; }
    }
}
