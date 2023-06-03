using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.EmployeeFaults.Queries;
using Infrastructure.EmployeeFaults.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EmployeeFaults.QueryHandlers
{
    public class GetEmployeeFaultToUpdateQueryHandler : IRequestHandler<GetEmployeeFaultToUpdateQuery, UpdateEmployeeFaultVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetEmployeeFaultToUpdateQueryHandler(DatabaseContext context,
                                                    IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UpdateEmployeeFaultVm> Handle(GetEmployeeFaultToUpdateQuery request, CancellationToken cancellationToken)
        {
            var ef = await _context.EmployeeFaults.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);


            return _mapper.Map<UpdateEmployeeFaultVm>(ef);

        }
    }
}
