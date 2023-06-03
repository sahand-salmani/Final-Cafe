using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Positions.Queries
{
    public class GetAllPositionSelectListQuery : IRequest<SelectList>
    {
        public GetAllPositionSelectListQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
