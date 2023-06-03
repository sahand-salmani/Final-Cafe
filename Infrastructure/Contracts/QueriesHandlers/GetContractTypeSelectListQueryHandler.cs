using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Contracts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Contracts.QueriesHandlers
{
    public class GetContractTypeSelectListQueryHandler : IRequestHandler<GetContractTypeSelectListQuery, SelectList>
    {
        public Task<SelectList> Handle(GetContractTypeSelectListQuery request, CancellationToken cancellationToken)
        {
            List<SelectListItem> selectListItems = Enum.GetValues(typeof(ContractType)).Cast<ContractType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

            var select = new SelectList(selectListItems);

            return Task.FromResult(select);
        }
    }
}
