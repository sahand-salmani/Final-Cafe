using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.Interns.Queries;
using Infrastructure.Interns.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interns.QueryHandlers
{
    public class GetInternByIdQueryHandler : IRequestHandler<GetInternByIdQuery, GetInternVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetInternByIdQueryHandler(DatabaseContext context,
                                         IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetInternVm> Handle(GetInternByIdQuery request, CancellationToken cancellationToken)
        {
            var intern = await _context.Interns.AsNoTracking().SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (intern is null)
            {
                return null;
            }

            GetInternVm result = _mapper.Map<GetInternVm>(intern);
            return result;
        }
    }
}
