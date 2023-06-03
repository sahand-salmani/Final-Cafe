﻿using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Pagination;
using Domain.Models;
using MediatR;

namespace Infrastructure.Contracts.Queries
{
    public class GetContractBySearchNameQuery : IRequest<PaginatedList<Contract>>
    {
        public GetContractBySearchNameQuery(string name, int page, int size)
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
