using System.Collections.Generic;
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
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<GetRoleVm>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetAllRolesQueryHandler(DatabaseContext context,
                                       IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetRoleVm>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _context.Roles.Include(e => e.Users).ThenInclude(e => e.User).ToListAsync(cancellationToken);

            return _mapper.Map<List<GetRoleVm>>(roles);
        }
    }
}
