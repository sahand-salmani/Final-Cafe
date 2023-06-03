using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Positions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Positions.QueryHandlers
{
    public class GetAllPositionSelectListQueryHandler : IRequestHandler<GetAllPositionSelectListQuery, SelectList>
    {
        private readonly DatabaseContext _context;

        public GetAllPositionSelectListQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<SelectList> Handle(GetAllPositionSelectListQuery request, CancellationToken cancellationToken)
        {
            var positions = await _context.Positions.ToListAsync(cancellationToken);
            if (request.Id != 0)
            {
                return new SelectList(positions, nameof(Position.Id), nameof(Position.Name), request.Id);
            }

            return new SelectList(positions, nameof(Position.Id), nameof(Position.Name));

        }
    }
}
