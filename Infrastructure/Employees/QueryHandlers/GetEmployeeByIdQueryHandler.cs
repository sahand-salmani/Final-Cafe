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
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(DatabaseContext context,
                                           IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetEmployeeVm> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.AsNoTracking().Include(e => e.Position)
                .Include(e => e.EmployeePayments).SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
            if (employee == null)
            {
                return null;
            }

            return _mapper.Map<GetEmployeeVm>(employee);
        }
    }
}
