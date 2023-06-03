using Infrastructure.Spends.ViewModels;
using MediatR;

namespace Infrastructure.Spends.Queries
{
    public class GetSpendToUpdateQuery : IRequest<EditSpendVm>
    {
        public GetSpendToUpdateQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
