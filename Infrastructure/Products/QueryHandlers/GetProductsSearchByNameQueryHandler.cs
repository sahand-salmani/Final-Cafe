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
    public class GetProductsSearchByNameQueryHandler : IRequestHandler<GetProductsSearchByNameQuery, PaginatedList<Product>>
    {
        private readonly DatabaseContext _context;

        public GetProductsSearchByNameQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Product>> Handle(GetProductsSearchByNameQuery request, CancellationToken cancellationToken)
        {
            var products = _context.Products.AsNoTracking().Include(e => e.Contracts)
                .Where(e => EF.Functions.Like(e.Name, $"%{request.Name}%"))
                .OrderByDescending(e => e.CreatedAt);

            return await PaginatedList<Product>.CreateAsync(products, request.Page, request.Size);
        }
    }
}
