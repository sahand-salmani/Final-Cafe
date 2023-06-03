using Infrastructure.BlackLists.ViewModels;
using MediatR;

namespace Infrastructure.BlackLists.Queries
{
    public class GetBlackListToUpdateQuery : IRequest<EditBlackListVm>
    {
        public int Id { get; set; }
        public GetBlackListToUpdateQuery(int id)
        {
            Id = id;
        }
    }
}
