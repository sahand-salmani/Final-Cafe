using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Domain.Users;
using Infrastructure.Users.Queries;
using Infrastructure.Users.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Users.QueryHandlers
{
    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, GetUserVm>
    {
        private readonly DatabaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public GetCurrentUserQueryHandler(DatabaseContext context,
                                          IHttpContextAccessor httpContextAccessor,
                                          IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        public async Task<GetUserVm> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _context.Users
                .AsNoTracking()
                .Include(e => e.Roles)
                .ThenInclude(e => e.Role)
                .Select(e => new ApplicationUser()
                {
                    Id = e.Id,
                    UserName = e.UserName,
                    Roles = e.Roles
                }).FirstOrDefaultAsync(e => e.Id == userId, cancellationToken);

            var model = _mapper.Map<GetUserVm>(user);



            return model;
        }
    }
}
