using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using MediatR;

namespace Infrastructure.Contracts.Queries
{
    public class GetLeastTimeRemainingContractsQuery : IRequest<List<Contract>>
    {
    }
}
