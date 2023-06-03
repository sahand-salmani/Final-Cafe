using DataAccess.Database;
using Infrastructure.Common;
using Infrastructure.Partners.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Partners.CommandHandlers
{
    public class DeletePartnersCommandHandler : IRequestHandler<DeletePartnersCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;

        public DeletePartnersCommandHandler(DatabaseContext context)
        {
           _context = context;
        }
        public async Task<OperationResult<int>> Handle(DeletePartnersCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var partner = await _context.Partners.FindAsync(request.Id);

            if (partner is null)
            {
                return result.AddError("Partner was not found");
            }

            _context.Partners.Remove(partner);

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
