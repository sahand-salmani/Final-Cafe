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
    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateContractCommandHandler(DatabaseContext context,
                                            IMapper mapper,
                                            IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<int>> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            if (request.Model.StartDate > request.Model.EndDate)
            {
                return result.AddError("Dating is not right.");
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

            var restaurantExists =
                await _context.Restaurants.AnyAsync(r => r.Id == request.Model.RestaurantId, cancellationToken);

            if (!restaurantExists)
            {
                return result.AddError("Restaurant was not found");
            }

            var validIds = await _context.Products.Select(x => x.Id).ToListAsync(cancellationToken);

            var allProductExists = request.Model.ProductsId.All(x => validIds.Contains(x));


            if (!allProductExists)
            {
                return result.AddError("Specified product was not found in database");
            }

            var employeeExists =
                await _context.Employees.AnyAsync(e => e.Id == request.Model.EmployeeId, cancellationToken);

            if (!employeeExists)
            {
                return result.AddError("Employee was not found");
            }

            request.Model.StartDate = request.Model.StartDate.ToAzDateTime();
            request.Model.EndDate = request.Model.EndDate.ToAzDateTime();

            var contract = _mapper.Map<Contract>(request.Model);

            contract.ContractType = request.Model.Yearly ? ContractType.Yearly : ContractType.Monthly;


            await _context.Contracts.AddAsync(contract, cancellationToken);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }


            var contractProducts = request.Model.ProductsId.Select(e => new ContractProduct() { ContractId = contract.Id, ProductId = e })
                .ToList();

            await _context.AddRangeAsync(contractProducts, cancellationToken);

            var cpPersistence = await _persistence.SaveChangesAsync();
            if (cpPersistence == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }


            result.Entity = contract.Id;
            return result;
        }
    }
}
