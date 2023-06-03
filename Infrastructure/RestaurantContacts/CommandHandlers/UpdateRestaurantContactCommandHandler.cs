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
    public class UpdateRestaurantContactCommandHandler : IRequestHandler<UpdateRestaurantContactCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public UpdateRestaurantContactCommandHandler(DatabaseContext context,
                                                     IMapper mapper,
                                                     IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<int>> Handle(UpdateRestaurantContactCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var rcExists = await _context.RestaurantContacts.AsNoTracking().AnyAsync(e => e.Id == request.Model.Id, cancellationToken);

            if (!rcExists)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            var updated = _mapper.Map<RestaurantContact>(request.Model);

            _context.RestaurantContacts.Update(updated);

            var persistenceResult = await _persistence.SaveChangesAsync();
            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = updated.RestaurantId;

            return result;

        }
    }
}
