using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Restaurants.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Restaurants.CommandHandlers
{
    public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IPersistence _persistence;
        private readonly IMapper _mapper;

        public UpdateRestaurantCommandHandler(DatabaseContext context,
                                              IPersistence persistence,
                                              IMapper mapper)
        {
            _context = context;
            _persistence = persistence;
            _mapper = mapper;
        }

        public async Task<OperationResult<int>> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            if (request.Id != request.Model.Id)
            {
                return result.AddError("Change in source code");
            }

            var restaurant = await _context.Restaurants.AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Model.Id, cancellationToken);

            if (restaurant is null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }




            var updated = _mapper.Map<Restaurant>(request.Model);


            if (request.Model.NetworkId != 0)
            {
                var networkExists = await _context.RestaurantNetworks.AsNoTracking()
                    .AnyAsync(e => e.Id == request.Model.NetworkId, cancellationToken);

                if (!networkExists)
                {
                    return result.AddError("Specified network was not found");
                }

                updated.RestaurantNetworkId = request.Model.NetworkId;
            }

            if (!await _context.RestaurantStatus.AnyAsync(e => e.Id == request.Model.StatusId, cancellationToken))
            {
                return result.AddError("Status was not found");
            }

            updated.RestaurantStatusId = request.Model.StatusId;



            _context.Restaurants.Update(updated);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult != 0)
            {
                result.Entity = restaurant.Id;
                return result;
            }

            return result.AddError(ErrorMessages.NotBeingAbleToUpdate);

        }
    }
}
