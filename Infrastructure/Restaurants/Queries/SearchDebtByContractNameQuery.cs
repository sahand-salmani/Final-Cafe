﻿using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.Restaurants.Queries
{
    public class SearchDebtByContractNameQuery : IRequest<PaginatedList<Restaurant>>
    {
        public SearchDebtByContractNameQuery(string name, int page, int size)
        {
            Name = name;
            Page = page;
            Size = size;
        }
        public string Name { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }

    }
}
