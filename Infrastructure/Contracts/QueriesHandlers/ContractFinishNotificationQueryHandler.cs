using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Database;
using Domain.Models;
using Humanizer;
using Humanizer.Localisation;
using Infrastructure.Common;
using Infrastructure.Contracts.Queries;
using Infrastructure.Contracts.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contracts.QueriesHandlers
{
    public class ContractFinishNotificationQueryHandler : IRequestHandler<ContractFinishNotificationQuery, List<ContractNotificationVm>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ContractFinishNotificationQueryHandler(DatabaseContext context,
                                                      IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ContractNotificationVm>> Handle(ContractFinishNotificationQuery request, CancellationToken cancellationToken)
        {
            if (request.Days == 0)
            {
                return new List<ContractNotificationVm>();
            }

            var now = DateTime.Now.ToAzDateTime();
            var wantedTime = DateTime.Now.ToAzDateTime().AddDays(request.Days);


            var contracts = await _context.Contracts
                .Where(e => e.EndDate < wantedTime)
                .Where(e => e.EndDate > now)
                .Include(e => e.Restaurant)
                .Take(request.Count)
                .Select(e => new Contract()
                {
                    Id = e.Id,
                    Name = e.Name,
                    EndDate = e.EndDate,
                    Restaurant = new Restaurant()
                    {
                        Name = e.Restaurant.Name
                    }
                })
                .ToListAsync(cancellationToken);

            var results = _mapper.Map<List<ContractNotificationVm>>(contracts);
            var cultInfo = CultureInfo.GetCultureInfo("az-Latn-AZ");
            foreach (var result in results)
            {
                result.Remaining = (now - result.EndDate).Humanize(2, maxUnit: TimeUnit.Day, minUnit:TimeUnit.Hour, culture: cultInfo);
            }
            return results;

        }
    }
}
