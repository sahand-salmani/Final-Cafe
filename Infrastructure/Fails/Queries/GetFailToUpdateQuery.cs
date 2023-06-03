using Infrastructure.Fails.ViewModels;
using MediatR;

namespace Infrastructure.Fails.Queries
{
    public class GetFailToUpdateQuery : IRequest<UpdateFailVm>
    {
        public GetFailToUpdateQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
