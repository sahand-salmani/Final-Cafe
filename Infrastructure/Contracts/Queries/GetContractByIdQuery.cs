using Infrastructure.Contracts.ViewModels;
using MediatR;

namespace Infrastructure.Contracts.Queries
{
    public class GetContractByIdQuery : IRequest<GetContractVm>
    {
        public GetContractByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
