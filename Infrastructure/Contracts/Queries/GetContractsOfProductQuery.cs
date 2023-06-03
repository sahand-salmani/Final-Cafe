using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.Contracts.Queries
{
    public class GetContractsOfProductQuery : IRequest<PaginatedList<Contract>>
    {
        public GetContractsOfProductQuery(int productId, int page, int size)
        {
            ProductId = productId;
            Page = page;
            Size = size;
        }
        public int ProductId { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
