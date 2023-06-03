using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.Restaurants.Queries
{
    public class GetRestaurantsOfStatusQuery : IRequest<PaginatedList<Restaurant>>
    {
        public GetRestaurantsOfStatusQuery(int statusId, int page, int size)
        {
            StatusId = statusId;
            Page = page;
            Size = size;
        }
        public int StatusId { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
