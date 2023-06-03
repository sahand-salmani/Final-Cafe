using System.Threading;
using System.Threading.Tasks;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.RestaurantContacts.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantContacts.CommandHandlers
{
    public class DeleteRestaurantContractQueryHandler : IRequestHandler<DeleteRestaurantContractQuery, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IPersistence _persistence;

        public DeleteRestaurantContractQueryHandler(DatabaseContext context,
                                                    IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<int>> Handle(DeleteRestaurantContractQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var rc = await _context.RestaurantContacts.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (rc is null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            _context.RestaurantContacts.Remove(rc);

            var persistenceResult = await _persistence.SaveChangesAsync();
            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.CouldNotDelete);
            }

            result.Entity = request.RestaurantId;
            return result;
        }
    }
}
