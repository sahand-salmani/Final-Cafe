using AutoMapper;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Partners.Queries;
using Infrastructure.Partners.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Partners.QueryHandlers
{
    public class GetPartnersToUpdateQueryHandler : IRequestHandler<GetPartnersToUpdateQuery, EditPartnersVm>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public GetPartnersToUpdateQueryHandler(DatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EditPartnersVm> Handle(GetPartnersToUpdateQuery request, CancellationToken cancellationToken)
        {
            var partner = await _context.Partners.AsNoTracking().SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (partner is null)
            {
                return null;
            }

            var model = _mapper.Map<EditPartnersVm>(partner);

            return model;
        }
    }
}
