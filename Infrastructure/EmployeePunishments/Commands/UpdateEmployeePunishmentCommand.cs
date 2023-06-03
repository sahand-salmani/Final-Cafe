using Infrastructure.Common;
using Infrastructure.EmployeePunishments.ViewModels;
using MediatR;

namespace Infrastructure.EmployeePunishments.Commands
{
    public class UpdateEmployeePunishmentCommand : IRequest<OperationResult<int>>
    {
        public UpdateEmployeePunishmentCommand(EditEmployeePunishmentVm model)
        {
            Model = model;
        }
        public EditEmployeePunishmentVm Model { get; set; }
    }
}
