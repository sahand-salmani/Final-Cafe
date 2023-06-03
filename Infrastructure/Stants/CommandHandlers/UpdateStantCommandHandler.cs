using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Stants.ViewModels;
using Infrastructure.Stants.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Stants.CommandHandlers
{
    public class UpdateStantCommandHandler : IRequestHandler<UpdateStantCommand, OperationResult<GetStantVm>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public UpdateStantCommandHandler(DatabaseContext context,IMapper mapper,IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<GetStantVm>> Handle(UpdateStantCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetStantVm>();
            if(request.Id != request.Model.Id)
            {
                return result.AddError(ErrorMessages.SourceCodeChange);
            }

            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(r => r.Id == request.Model.RestaurantId,cancellationToken);
            if(result is null)
            {
                return result.AddError("Restaurant is not found");
            }

            var updateStant = _mapper.Map<Stant>(request.Model);
            _context.Stants.Update(updateStant);

            var persistence = await _persistence.SaveChangesAsync();

            if(persistence == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = _mapper.Map<GetStantVm>(updateStant);

            return result;
        }
    }
}
