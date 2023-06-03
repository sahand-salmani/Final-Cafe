using Infrastructure.Contracts.ViewModels;
using MediatR;

namespace Infrastructure.Contracts.Queries
{
    public class GetContractToUpdateQuery : IRequest<UpdateContractVm>
    {
        public GetContractToUpdateQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
