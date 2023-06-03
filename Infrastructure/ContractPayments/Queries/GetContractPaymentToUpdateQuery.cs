using Infrastructure.ContractPayments.ViewModels;
using MediatR;

namespace Infrastructure.ContractPayments.Queries
{
    public class GetContractPaymentToUpdateQuery : IRequest<UpdateContractPaymentVm>
    {
        public GetContractPaymentToUpdateQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
