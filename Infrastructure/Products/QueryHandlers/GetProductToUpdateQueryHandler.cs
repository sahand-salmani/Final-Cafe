using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Infrastructure.Products.Queries;
using Infrastructure.Products.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Products.QueryHandlers
{
    public class GetProductToUpdateQueryHandler : IRequestHandler<GetProductToUpdateQuery, UpdateProductVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetProductToUpdateQueryHandler(DatabaseContext context,
                                              IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UpdateProductVm> Handle(GetProductToUpdateQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (product is null)
            {
                return null;
            }

            return _mapper.Map<UpdateProductVm>(product);
        }
    }
}
