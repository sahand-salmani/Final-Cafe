using Infrastructure.Common;
using Infrastructure.EmployeeFaults.ViewModels;
using MediatR;

namespace Infrastructure.EmployeeFaults.Commands
{
    public class CreateEmployeeFaultCommand : IRequest<OperationResult<int>>
    {
        public CreateEmployeeFaultCommand(CreateEmployeeFaultVm model)
        {
            Model = model;
        }
        public CreateEmployeeFaultVm Model { get; set; }
    }
}
