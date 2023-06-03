using DataAccess.Pagination;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Partners.Queries
{
    public class GetAllPartnersQuery : IRequest<PaginatedList<Partner>>
    {

        public int Page { get; set; }
        public int Size { get; set; }

        public GetAllPartnersQuery(int size, int page)
        {
            Page = page;
            Size = size;
        }
    }
}
