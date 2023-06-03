using Infrastructure.Common;
using Infrastructure.PrePayments.ViewModels;
using MediatR;

namespace Infrastructure.PrePayments.Commands
{
    public class EditPrePaymentCommand: IRequest<OperationResult<GetPrePaymentVm>>
    {
        public EditPrePaymentCommand(EditPrePaymentVm model, int id)
        {
            Model = model;
            Id = id;
        }
        public EditPrePaymentVm Model { get; set; }
        public int Id { get; set; }
    }
}
