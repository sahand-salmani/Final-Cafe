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
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(DatabaseContext context,
                                          IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetProductVm> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Include(e => e.Contracts).ThenInclude(e => e.Contract)
                .ThenInclude(e => e.Restaurant).AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (product is null)
            {
                return null;
            }

            return _mapper.Map<GetProductVm>(product);
        }
    }
}
