using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.Employees.Queries;
using Infrastructure.Employees.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Employees.QueryHandlers
{
    public class GetEmployeeToUpdateQueryHandler : IRequestHandler<GetEmployeeToUpdateQuery, EditEmployeeVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetEmployeeToUpdateQueryHandler(DatabaseContext context,
                                               IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<EditEmployeeVm> Handle(GetEmployeeToUpdateQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.Include(e => e.Position)
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            return _mapper.Map<EditEmployeeVm>(employee);
        }
    }
}
