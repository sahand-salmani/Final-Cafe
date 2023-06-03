using AutoMapper;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.Partners.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Partners.CommandHandlers
{
    public class UpdatePartnersCommandHandler : IRequestHandler<UpdatePartnersCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public UpdatePartnersCommandHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OperationResult<int>> Handle(UpdatePartnersCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var partner = await _context.Partners.AsNoTracking().SingleOrDefaultAsync(c => c.Id == request.Model.Id, cancellationToken);

            if (partner is null)
            {
                return result.AddError("Partner was not found");
            }

            var edit = _mapper.Map<Partner>(request.Model);

            _context.Partners.Update(edit);

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
