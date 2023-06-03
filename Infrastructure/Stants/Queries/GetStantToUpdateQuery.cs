using Infrastructure.Stants.ViewModels;
using MediatR;

namespace Infrastructure.Stants.Queries
{
    public class GetStantToUpdateQuery : IRequest<UpdateStantVm>
    {
        public GetStantToUpdateQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
