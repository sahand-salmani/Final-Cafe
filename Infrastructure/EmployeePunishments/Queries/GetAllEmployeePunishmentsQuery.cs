using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.EmployeePunishments.Queries
{
    public class GetAllEmployeePunishmentsQuery : IRequest<PaginatedList<EmployeePunishment>>
    {
        public GetAllEmployeePunishmentsQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
