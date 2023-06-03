using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.Fails.Queries;
using Infrastructure.Fails.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Fails.QueryHandlers
{
    public class GetFailToUpdateQueryHandler : IRequestHandler<GetFailToUpdateQuery, UpdateFailVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetFailToUpdateQueryHandler(DatabaseContext context,
                                           IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UpdateFailVm> Handle(GetFailToUpdateQuery request, CancellationToken cancellationToken)
        {
            var fail = await _context.Fails.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (fail is null)
            {
                return null;
            }

            return _mapper.Map<UpdateFailVm>(fail);
        }
    }
}
