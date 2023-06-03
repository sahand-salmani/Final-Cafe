using Infrastructure.PrePayments.ViewModels;
using MediatR;

namespace Infrastructure.PrePayments.Queries
{
    public class GetPrePaymentToUpdateQuery:IRequest<EditPrePaymentVm>
    {
        public GetPrePaymentToUpdateQuery(int id)
        {
            Id =id;
        }
        public int Id { get; set; }
    }
}
