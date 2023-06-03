using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Products.Commands;
using Infrastructure.Products.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Products.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, OperationResult<GetProductVm>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public UpdateProductCommandHandler(DatabaseContext context,
                                           IMapper mapper,
                                           IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<GetProductVm>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetProductVm>();

            var updated = _mapper.Map<Product>(request.Model);

            _context.Products.Update(updated);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            var productWithDetails = await _context.Products.Include(e => e.Contracts).ThenInclude(e => e.Contract)
                .SingleOrDefaultAsync(e => e.Id == updated.Id, cancellationToken);


            result.Entity = _mapper.Map<GetProductVm>(productWithDetails);

            return result;
        }
    }
}
