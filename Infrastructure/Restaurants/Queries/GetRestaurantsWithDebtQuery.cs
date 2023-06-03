using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Pagination;
using Domain.Models;
using Infrastructure.Restaurants.ViewModels;
using MediatR;

namespace Infrastructure.Restaurants.Queries
{
    public class GetRestaurantsWithDebtQuery : IRequest<PaginatedList<Restaurant>>
    {
        public GetRestaurantsWithDebtQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
