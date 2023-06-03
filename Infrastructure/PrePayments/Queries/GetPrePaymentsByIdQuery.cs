using Infrastructure.PrePayments.ViewModels;
using MediatR;

namespace Infrastructure.PrePayments.Queries
{
    public class GetPrePaymentsByIdQuery:IRequest<GetPrePaymentVm>
    {
        public GetPrePaymentsByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
       
    }
}
