using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Products.Commands;
using MediatR;

namespace Infrastructure.Products.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateProductCommandHandler(DatabaseContext context,
                                           IMapper mapper,
                                           IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var product = _mapper.Map<Product>(request);

            await _context.Products.AddAsync(product, cancellationToken);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            result.Entity = product.Id;

            return result;
        }
    }
}
