using Infrastructure.Spends.ViewModels;
using MediatR;

namespace Infrastructure.Spends.Queries
{
    public class GetSpendByIdQuery : IRequest<GetSpendVm>
    {
        public int Id { get; set; }
        public GetSpendByIdQuery(int id)
        {
            Id = id;
        }
        public static GetSpendByIdQuery Get(int id) => new GetSpendByIdQuery(id);
    }
}
