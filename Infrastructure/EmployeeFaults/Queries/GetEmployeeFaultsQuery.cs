using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.EmployeeFaults.Queries
{
    public class GetEmployeeFaultsQuery : IRequest<PaginatedList<EmployeeFault>>
    {
        public GetEmployeeFaultsQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
