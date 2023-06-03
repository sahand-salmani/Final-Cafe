using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Stants.Queries
{
    public class GetStantSelectListQuery : IRequest<SelectList>
    {
        public GetStantSelectListQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
