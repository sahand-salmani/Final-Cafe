using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.EmployeePunishments.Queries;
using Infrastructure.EmployeePunishments.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EmployeePunishments.QueryHandlers
{
    public class GetEmployeePunishmentToUpdateQueryHandler : IRequestHandler<GetEmployeePunishmentToUpdateQuery, EditEmployeePunishmentVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetEmployeePunishmentToUpdateQueryHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<EditEmployeePunishmentVm> Handle(GetEmployeePunishmentToUpdateQuery request, CancellationToken cancellationToken)
        {
            var p = await _context.EmployeePunishments.AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (p is null)
            {
                return null;
            }

            var model = _mapper.Map<EditEmployeePunishmentVm>(p);

            return model;
        }
    }
}
