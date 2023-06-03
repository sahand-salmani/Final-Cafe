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
    public class CreateRestaurantNetworkCommandHandler : IRequestHandler<CreateRestaurantNetworkCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CreateRestaurantNetworkCommandHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OperationResult<int>> Handle(CreateRestaurantNetworkCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var checkExists = await _context.RestaurantNetworks.AsNoTracking()
                .AnyAsync(e => e.Name.ToUpper() == request.Model.Name.ToUpper(), cancellationToken);


            if (checkExists)
            {
                return result.AddError("This network already exists");
            }

            var newNetwork = _mapper.Map<RestaurantNetwork>(request.Model);

            await _context.RestaurantNetworks.AddAsync(newNetwork, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            result.Entity = newNetwork.Id;

            return result;

        }
    }
}
