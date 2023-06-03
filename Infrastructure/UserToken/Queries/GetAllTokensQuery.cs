using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.UserToken.Queries
{
    public class GetAllTokensQuery : IRequest<PaginatedList<UserRegisterToken>>
    {
        public GetAllTokensQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
