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
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateRestaurantCommandHandler(DatabaseContext context,
                                              IMapper mapper,
                                              IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<int>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var status =
                await _context.RestaurantStatus.FirstOrDefaultAsync(
                    e => e.Id == request.Model.CreateRestaurantVm.StatusId, cancellationToken);
            if (status is null)
            {
                return result.AddError("Specified status was not found");
            }

            var restaurant = _mapper.Map<Restaurant>(request.Model.CreateRestaurantVm);
            restaurant.RestaurantStatusId = status.Id;
            if (request.Model.CreateRestaurantVm.NetworkId != 0)
            {
                var checkNetworkExists =
                    await _context.RestaurantNetworks.AnyAsync(e => e.Id == request.Model.CreateRestaurantVm.NetworkId,
                        cancellationToken);
                if (!checkNetworkExists)
                {
                    return result.AddError("Network was not found");
                }

                restaurant.RestaurantNetworkId = request.Model.CreateRestaurantVm.NetworkId;
            }
            else
            {
                restaurant.RestaurantNetworkId = null;
            }
            await _context.Restaurants.AddAsync(restaurant, cancellationToken);
            var restaurantPersistence = await _persistence.SaveChangesAsync();

            var contactDetails = _mapper.Map<RestaurantContact>(request.Model.CreateRestaurantContactVm);
            contactDetails.RestaurantId = restaurant.Id;

            await _context.RestaurantContacts.AddAsync(contactDetails,cancellationToken);

            var persistence = await _persistence.SaveChangesAsync();

            if (persistence == 0) return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            result.Entity = restaurant.Id;
            return result;
        }
    }
}
