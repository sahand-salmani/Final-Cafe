using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Products.Queries
{
    public class GetProductsMultiSelectListQuery : IRequest<MultiSelectList>
    {
        public GetProductsMultiSelectListQuery(List<int> products)
        {
            Products = products ?? new List<int>();
        }

        public GetProductsMultiSelectListQuery(int id, List<int> products)
        {
            Id = id;
            Products = new List<int>();
        }

        public GetProductsMultiSelectListQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public List<int> Products { get; set; }

    }
}
