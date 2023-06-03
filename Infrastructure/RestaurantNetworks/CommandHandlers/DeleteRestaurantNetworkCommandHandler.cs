using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Infrastructure.Common;
using Infrastructure.RestaurantNetworks.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantNetworks.CommandHandlers
{
    public class DeleteRestaurantNetworkCommandHandler : IRequestHandler<DeleteRestaurantNetworkCommand, OperationResult<Unit>>
    {
        private readonly DatabaseContext _context;

        public DeleteRestaurantNetworkCommandHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteRestaurantNetworkCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var network = await _context.RestaurantNetworks.Include(e => e.Restaurants)
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (network.Restaurants != null && network.Restaurants.Any())
            {
                return result.AddError("This network has restaurants and can not be deleted");
            }


            _context.RestaurantNetworks.Remove(network);

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
