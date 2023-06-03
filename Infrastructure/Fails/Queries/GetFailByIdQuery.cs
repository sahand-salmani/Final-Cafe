using Infrastructure.Fails.ViewModels;
using MediatR;

namespace Infrastructure.Fails.Queries
{
    public class GetFailByIdQuery : IRequest<GetFailsVm>
    {
        public GetFailByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

    }
}
