using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.Restaurants.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Restaurants.CommandHandlers
{
    public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, OperationResult<Unit>>
    {
        private readonly DatabaseContext _context;
        private readonly IPersistence _persistence;

        public DeleteRestaurantCommandHandler(DatabaseContext context, IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var restaurant =
                await _context.Restaurants.Include(e => e.Stants).Include(e => e.Contract).SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (restaurant is null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            if (restaurant.Contract != null && restaurant.Contract.Any())
            {
                return result.AddError("This Restaurant has contract and can not be deleted");
            }

            if (restaurant.Stants != null && restaurant.Stants.Any())
            {
                return result.AddError("This Restaurant has stands and can not be deleted");
            }


            _context.Restaurants.Remove(restaurant);

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
