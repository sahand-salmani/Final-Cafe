using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Infrastructure.Common;
using Infrastructure.RestaurantStatuses.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantStatuses.CommandHandlers
{
    public class DeleteRestaurantStatusCommandHandler : IRequestHandler<DeleteRestaurantStatusCommand, OperationResult<Unit>>
    {
        private readonly DatabaseContext _context;

        public DeleteRestaurantStatusCommandHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteRestaurantStatusCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var rs = await _context.RestaurantStatus.Include(e => e.Restaurants).SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);


            if (rs.Restaurants != null)
            {
                if (rs.Restaurants.Any())
                {
                    return result.AddError("There are Restaurant associated to this status and can not be deleted");
                }
            }

            _context.RestaurantStatus.Remove(rs);

            await _context.SaveChangesAsync(cancellationToken);


            return result;

        }
    }
}
