using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.Stants.Queries;
using Infrastructure.Stants.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Stants.QueryHandlers
{
    public class GetStantToUpdateQueryHandler : IRequestHandler<GetStantToUpdateQuery, UpdateStantVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetStantToUpdateQueryHandler(DatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UpdateStantVm> Handle(GetStantToUpdateQuery request, CancellationToken cancellationToken)
        {
            var stant = await _context.Stants.Include(r => r.Restaurant)
                .SingleOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            return _mapper.Map<UpdateStantVm>(stant);
        }
    }
}
