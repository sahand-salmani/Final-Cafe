using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.Roles.Queries;
using Infrastructure.Roles.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Roles.QueryHandlers
{
    public class GetRoleByNameQueryHandler : IRequestHandler<GetRoleByNameQuery, GetRoleVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetRoleByNameQueryHandler(DatabaseContext context,
                                         IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetRoleVm> Handle(GetRoleByNameQuery request, CancellationToken cancellationToken)
        {
            var role = await _context.Roles.SingleOrDefaultAsync(e => e.Name == request.Name, cancellationToken);
            if (role is null)
            {
                return null;
            }

            return _mapper.Map<GetRoleVm>(role);


        }
    }
}
