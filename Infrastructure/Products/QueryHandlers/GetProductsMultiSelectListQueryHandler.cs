using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Products.QueryHandlers
{
    public class GetProductsMultiSelectListQueryHandler : IRequestHandler<GetProductsMultiSelectListQuery, MultiSelectList>
    {
        private readonly DatabaseContext _context;

        public GetProductsMultiSelectListQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<MultiSelectList> Handle(GetProductsMultiSelectListQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.Include(e => e.Contracts).AsNoTracking().ToListAsync(cancellationToken);

            if (request.Id != 0)
            {
                List<int> contractProducts = await _context.ContractProducts.Where(e => e.ContractId == request.Id)
                    .Select(e => e.ProductId).ToListAsync(cancellationToken);
                return new MultiSelectList(products, nameof(Product.Id), nameof(Product.Name), contractProducts);
            }


            return new MultiSelectList(products, nameof(Product.Id), nameof(Product.Name), request.Products);
        }
    }
}
