using Infrastructure.Common;
using Infrastructure.EmployeePunishments.ViewModels;
using MediatR;

namespace Infrastructure.EmployeePunishments.Commands
{
    public class CreateEmployeePunishmentCommand : IRequest<OperationResult<int>>
    {
        public CreateEmployeePunishmentCommand(CreateEmployeePunishmentVm model)
        {
            Model = model;
        }
        public CreateEmployeePunishmentVm Model { get; set; }
    }
}
