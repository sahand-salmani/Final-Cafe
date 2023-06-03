using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Products.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Products.QueryHandlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PaginatedList<Product>>
    {
        private readonly DatabaseContext _context;

        public GetAllProductsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = _context.Products.Include(e => e.Contracts).AsNoTracking().OrderByDescending(e => e.CreatedAt);

            return await PaginatedList<Product>.CreateAsync(result, request.Page, request.Size);
        }
    }
}
