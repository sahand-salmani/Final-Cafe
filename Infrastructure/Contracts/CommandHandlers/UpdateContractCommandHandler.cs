using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Contracts.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contracts.CommandHandlers
{
    public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public UpdateContractCommandHandler(DatabaseContext context,
                                            IMapper mapper,
                                            IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<int>> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();
            var contract = await _context.Contracts.Include(e=> e.ContractProducts).AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Model.Id, cancellationToken);

            if (contract is null)
            {
                return result.AddError("Contract was not found");
            }

            if (request.Model.EmployeeId == 0)
            {
                return result.AddError("Employee was not selected");
            }

            if (request.Model.ProductsId == null)
            {
                return result.AddError("Product was not selected");
            }

            if (!request.Model.ProductsId.Any())
            {
                return result.AddError("Product was not selected");
            }

            var employeeExists =
                await _context.Employees.AnyAsync(e => e.Id == request.Model.EmployeeId, cancellationToken);
            if (!employeeExists)
            {
                return result.AddError("Employee was not found");
            }

            var deletedProductContracts =
                await _context.ContractProducts.Where(e => e.ContractId == contract.Id).ToListAsync(cancellationToken);
            _context.RemoveRange(deletedProductContracts);
            await _persistence.SaveChangesAsync();

            var updated = _mapper.Map<Contract>(request.Model);
            updated.ContractType = request.Model.Yearly ? ContractType.Yearly : ContractType.Monthly;
            updated.RestaurantId = contract.RestaurantId;
            _context.Update(updated);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            var newContractProds = request.Model.ProductsId.Select(e => new ContractProduct()
                { ContractId = updated.Id, ProductId = e }).ToList();
            await _context.ContractProducts.AddRangeAsync(newContractProds, cancellationToken);
            var cpResult = await _persistence.SaveChangesAsync();


            result.Entity = contract.Id;
            return result;

        }
    }
}
