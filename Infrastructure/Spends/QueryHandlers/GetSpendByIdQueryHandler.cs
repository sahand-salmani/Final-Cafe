using AutoMapper;
using DataAccess.Database;
using Infrastructure.Spends.Queries;
using Infrastructure.Spends.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Spends.QueryHandlers
{
    public class GetSpendByIdQueryHandler : IRequestHandler<GetSpendByIdQuery, GetSpendVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetSpendByIdQueryHandler(DatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetSpendVm> Handle(GetSpendByIdQuery request, CancellationToken cancellationToken)
        {
            var spend = await _context.Spends.AsNoTracking().SingleOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if(spend is null)
            {
                return null;
            }

            GetSpendVm result = _mapper.Map<GetSpendVm>(spend);

            return result;
        }
    }
}
