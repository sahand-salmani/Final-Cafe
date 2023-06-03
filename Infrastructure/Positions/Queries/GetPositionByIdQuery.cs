using Infrastructure.Positions.ViewModels;
using MediatR;

namespace Infrastructure.Positions.Queries
{
    public class GetPositionByIdQuery : IRequest<GetPositionVm>
    {
        public GetPositionByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
