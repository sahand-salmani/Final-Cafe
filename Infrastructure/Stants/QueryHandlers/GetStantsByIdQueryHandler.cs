using AutoMapper;
using DataAccess.Database;
using Infrastructure.Stants.ViewModels;
using Infrastructure.Stants.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Stants.QueryHandlers
{
    public class GetStantsByIdQueryHandler : IRequestHandler<GetStantsByIdQuery, GetStantVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetStantsByIdQueryHandler(DatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetStantVm> Handle(GetStantsByIdQuery request, CancellationToken cancellationToken)
        {
            var stant = await _context.Stants.AsNoTracking().Include(s => s.Restaurant).
                SingleOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
            if(stant is null)
            {
                return null;
            }

            return _mapper.Map<GetStantVm>(stant);
        }
    }
}
