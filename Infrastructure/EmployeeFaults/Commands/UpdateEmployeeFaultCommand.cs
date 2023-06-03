using Infrastructure.Common;
using Infrastructure.EmployeeFaults.ViewModels;
using MediatR;

namespace Infrastructure.EmployeeFaults.Commands
{
    public class UpdateEmployeeFaultCommand : IRequest<OperationResult<int>>
    {
        public UpdateEmployeeFaultCommand(UpdateEmployeeFaultVm model)
        {
            Model = model;
        }
        public UpdateEmployeeFaultVm Model { get; set; }
    }
}
