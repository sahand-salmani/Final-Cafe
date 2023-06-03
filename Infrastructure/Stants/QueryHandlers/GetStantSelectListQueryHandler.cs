using DataAccess.Database;
using Domain.Models;
using Infrastructure.Stants.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Stants.QueryHandlers
{
    public class GetStantSelectListQueryHandler : IRequestHandler<GetStantSelectListQuery, SelectList>
    {
        private readonly DatabaseContext _context;

        public GetStantSelectListQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<SelectList> Handle(GetStantSelectListQuery request, CancellationToken cancellationToken)
        {
            var stants = await _context.Stants.AsNoTracking().OrderBy(s => s.Quantity).ToListAsync(cancellationToken);

            return new SelectList(stants, nameof(Stant.Id), nameof(Stant.Quantity), request.Id);
        }
    }
}
