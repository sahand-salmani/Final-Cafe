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
    public class CreateRestaurantStatusCommandHandler : IRequestHandler<CreateRestaurantStatusCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CreateRestaurantStatusCommandHandler(DatabaseContext context,
                                                    IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OperationResult<int>> Handle(CreateRestaurantStatusCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var checkStatusExists =
                await _context.RestaurantStatus.AnyAsync(e => e.Name == request.Model.Name, cancellationToken);

            if (checkStatusExists)
            {
                return result.AddError("This status already exists");
            }

            var newStatus = _mapper.Map<RestaurantStatus>(request.Model);

            await _context.RestaurantStatus.AddAsync(newStatus, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            result.Entity = newStatus.Id;

            return result;
        }
    }
}
