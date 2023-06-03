using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Stants.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Stants.CommandHandlers
{
    public class CreateStantCommandHandler : IRequestHandler<CreateStantCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateStantCommandHandler(DatabaseContext context,IMapper mapper,IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<int>> Handle(CreateStantCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(s => s.Id == request.Model.RestaurantId,cancellationToken);
            if(restaurant is null)
            {
                return result.AddError("Could not find the specified restaurant");
            }

            var stant = _mapper.Map<Stant>(request.Model);

            await _context.Stants.AddAsync(stant,cancellationToken);
            var persistence = await _persistence.SaveChangesAsync();

            if(persistence == 0)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            result.Entity = stant.Id;
            return result;
        }
    }
}
