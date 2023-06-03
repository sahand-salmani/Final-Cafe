using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Contracts.Queries;
using Infrastructure.Contracts.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contracts.QueriesHandlers
{
    public class GetContractByIdQueryHandler : IRequestHandler<GetContractByIdQuery, GetContractVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetContractByIdQueryHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetContractVm> Handle(GetContractByIdQuery request, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts
                .Include(e => e.Employee)
                .Include(e => e.Restaurant)
                .Include(e => e.ContractProducts)
                .ThenInclude(e => e.Product)
                .Include(e => e.ContractPayments)
                .AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (contract is null)
            {
                return null;
            }

            var model = _mapper.Map<GetContractVm>(contract);

            model.ContractType = contract.ContractType == ContractType.Monthly ? "Monthly" : "Yearly";


            model.Remains = contract.Payment - contract.ContractPayments.Sum(e => e.Amount);


            return model;
        }
    }
}
