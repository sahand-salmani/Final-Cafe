using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Domain.Users;
using Infrastructure.Users.Queries;
using Infrastructure.Users.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Users.QueryHandlers
{
    public class GetUserToUpdateQueryHandler : IRequestHandler<GetUserToUpdateQuery, EditUserRoleVm>
    {
        private readonly DatabaseContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public GetUserToUpdateQueryHandler(DatabaseContext context,
                                           RoleManager<ApplicationRole> roleManager,
                                           IMapper mapper)
        {
            _context = context;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<EditUserRoleVm> Handle(GetUserToUpdateQuery request, CancellationToken cancellationToken)
        {

            var user = await _context.Users.Include(e => e.Roles)
                .AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (user is null)
            {
                return null;
            }


            var model = _mapper.Map<EditUserRoleVm>(user);


            var roles = await _roleManager.Roles.ToListAsync(cancellationToken);

            if (!user.Roles.Any())
            {
                model.SelectList =
                    new MultiSelectList(roles, nameof(ApplicationRole.Id), nameof(ApplicationRole.Name));
                return model;
            }


            var selected = user.Roles.Select(e => e.RoleId).ToList();
            model.SelectList =
                new MultiSelectList(roles, nameof(ApplicationRole.Id), nameof(ApplicationRole.Name), selected);
            model.RoleId = selected;

            return model;


        }
    }
}
