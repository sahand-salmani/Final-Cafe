using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.Positions.Queries;
using Infrastructure.Positions.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Positions.QueryHandlers
{
    public class GetPositionByIdQueryHandler : IRequestHandler<GetPositionByIdQuery, GetPositionVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetPositionByIdQueryHandler(DatabaseContext context,
                                           IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetPositionVm> Handle(GetPositionByIdQuery request, CancellationToken cancellationToken)
        {
            var position = await _context.Positions.AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (position is null)
            {
                return null;
            }

            return _mapper.Map<GetPositionVm>(position);
        }
    }
}
