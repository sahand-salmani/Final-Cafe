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
    public class GetContractToUpdateQueryHandler : IRequestHandler<GetContractToUpdateQuery, UpdateContractVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetContractToUpdateQueryHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UpdateContractVm> Handle(GetContractToUpdateQuery request, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts.Include(e => e.ContractProducts).AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (contract is null)
            {
                return null;
            }

            var result =  _mapper.Map<UpdateContractVm>(contract);
            result.Yearly = contract.ContractType == ContractType.Yearly;
            result.ProductsId = contract.ContractProducts.Select(e => e.ProductId).ToList();
            return result;
        }
    }
}
