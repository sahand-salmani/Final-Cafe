using AutoMapper;
using DataAccess.Database;
using Infrastructure.BlackLists.Queries;
using Infrastructure.BlackLists.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.BlackLists.QueryHandlers
{
    public class GetBlackListToUpdateQueryHandler : IRequestHandler<GetBlackListToUpdateQuery, EditBlackListVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetBlackListToUpdateQueryHandler(DatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<EditBlackListVm> Handle(GetBlackListToUpdateQuery request, CancellationToken cancellationToken)
        {
            var b = await _context.BlackLists.AsNoTracking()
                .SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if(b is null)
            {
                return null;
            }

            var model = _mapper.Map<EditBlackListVm>(b);

            return model;
        }
    }
}
