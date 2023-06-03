using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.RestaurantNetworks.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantNetworks.CommandHandlers
{
    public class UpdateRestaurantNetworkCommandHandler : IRequestHandler<UpdateRestaurantNetworkCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public UpdateRestaurantNetworkCommandHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OperationResult<int>> Handle(UpdateRestaurantNetworkCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var rn = await _context.RestaurantNetworks.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == request.Model.Id, cancellationToken);

            if (rn is null)
            {
                return result.AddError("Network was not found");
            }

            var updated = _mapper.Map<RestaurantNetwork>(request.Model);

            _context.RestaurantNetworks.Update(updated);

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
