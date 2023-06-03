using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.Products.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Products.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, OperationResult<Unit>>
    {
        private readonly DatabaseContext _context;
        private readonly IPersistence _persistence;

        public DeleteProductCommandHandler(DatabaseContext context,
                                           IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var product = await _context.Products
                .Include(e => e.Contracts)
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (product.Contracts.Any())
            {
                return result.AddError("This product is included in a contract. Can not be deleted");
            }

            _context.Products.Remove(product);

            var persistenceResult = await _persistence.SaveChangesAsync();
            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.CouldNotDelete);
            }

            result.Entity = Unit.Value;
            return result;
        }
    }
}
