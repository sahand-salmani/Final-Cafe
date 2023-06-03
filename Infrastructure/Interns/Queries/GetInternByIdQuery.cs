using Infrastructure.Interns.ViewModels;
using MediatR;

namespace Infrastructure.Interns.Queries
{
    public class GetInternByIdQuery : IRequest<GetInternVm>
    {
        public int Id { get; set; }

        public GetInternByIdQuery(int id)
        {
            Id = id;
        }
        public static GetInternByIdQuery Get(int id) => new GetInternByIdQuery(id);
    }
}
