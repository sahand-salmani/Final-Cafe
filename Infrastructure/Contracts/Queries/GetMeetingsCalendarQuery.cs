using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Contracts.ViewModels;
using MediatR;

namespace Infrastructure.Contracts.Queries
{
    public class GetContractsCalendarQuery : IRequest<List<ContractCalendarVm>>
    {
    }
}
