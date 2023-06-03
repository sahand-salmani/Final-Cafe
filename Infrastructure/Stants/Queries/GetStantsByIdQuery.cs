using Infrastructure.Stants.ViewModels;
using MediatR;

namespace Infrastructure.Stants.Queries
{
    public class GetStantsByIdQuery : IRequest<GetStantVm>
    {
        public GetStantsByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
