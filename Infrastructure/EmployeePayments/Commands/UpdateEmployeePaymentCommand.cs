using Infrastructure.Common;
using Infrastructure.EmployeePayments.ViewModels;
using MediatR;

namespace Infrastructure.EmployeePayments.Commands
{
    public class UpdateEmployeePaymentCommand : IRequest<OperationResult<GetEmployeePaymentVm>>
    {
        public UpdateEmployeePaymentCommand(UpdateEmployeePaymentVm model,int id)
        {
            Id = id;
            Model = model;
        }
        public UpdateEmployeePaymentVm Model { get; set; }
        public int Id { get; set; }
    }
}
