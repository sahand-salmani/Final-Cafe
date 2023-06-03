using Infrastructure.Common;
using Infrastructure.Employees.ViewModels;
using MediatR;

namespace Infrastructure.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<OperationResult<int>>
    {
        public CreateEmployeeCommand(CreateEmployeeVm model)
        {
            Model = model;
        }
        public CreateEmployeeVm Model { get; set; }
    }
}
