using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.Spends.Queries;
using Infrastructure.Spends.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Spends.QueryHandlers
{
    public class GetSpendToUpdateQueryHandler : IRequestHandler<GetSpendToUpdateQuery, EditSpendVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetSpendToUpdateQueryHandler(DatabaseContext context,
                                            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<EditSpendVm> Handle(GetSpendToUpdateQuery request, CancellationToken cancellationToken)
        {
            var spend = await _context.Spends.AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (spend is null)
            {
                return null;
            }

            return _mapper.Map<EditSpendVm>(spend);
        }
    }
}
