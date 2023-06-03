using Infrastructure.Common;
using Infrastructure.Employees.ViewModels;
using MediatR;

namespace Infrastructure.Employees.Commands
{
    public class EditEmployeeCommand : IRequest<OperationResult<GetEmployeeVm>>
    {
        public EditEmployeeCommand(int id, EditEmployeeVm model)
        {
            Id = id;
            Model = model;
        }
        public int Id { get; set; }
        public EditEmployeeVm Model { get; set; }
    }
}
