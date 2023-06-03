using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.RestaurantContacts.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantContacts.CommandHandlers
{
    class CreateRestaurantContactCommandHandler : IRequestHandler<CreateRestaurantContactCommand,OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateRestaurantContactCommandHandler(DatabaseContext context,IMapper mapper,IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<int>> Handle(CreateRestaurantContactCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();
            var restaurantExist = await _context.Restaurants.AnyAsync(r => r.Id == request.Model.RestaurantId,cancellationToken);
            if (!restaurantExist)
            {
                return result.AddError("Restaurant was not found");
            }

            var restaurantContact = _mapper.Map<RestaurantContact>(request.Model);
            restaurantContact.RestaurantId = request.Model.RestaurantId;
            await _context.AddAsync(restaurantContact,cancellationToken);

            var persistence = await _persistence.SaveChangesAsync();

            if (persistence == 0) return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            result.Entity = restaurantContact.Id;

            return result;
        }
    }
}
