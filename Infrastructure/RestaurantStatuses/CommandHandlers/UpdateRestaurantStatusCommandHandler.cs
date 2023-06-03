using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.RestaurantStatuses.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RestaurantStatuses.CommandHandlers
{
    public class UpdateRestaurantStatusCommandHandler : IRequestHandler<UpdateRestaurantStatusCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public UpdateRestaurantStatusCommandHandler(DatabaseContext context,
                                                    IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OperationResult<int>> Handle(UpdateRestaurantStatusCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var rs = await _context.RestaurantStatus.AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Model.Id, cancellationToken);


            //if (rs.Restaurants != null)
            //{
            //    if (rs.Restaurants.Any())
            //    {
            //        return result.AddError("There are Restaurant associated to this status and can not be deleted");
            //    }
            //}

            var updated = _mapper.Map<RestaurantStatus>(request.Model);

            _context.RestaurantStatus.Update(updated);

            await _context.SaveChangesAsync(cancellationToken);

            result.Entity = updated.Id;
            return result;

        }
    }
}
