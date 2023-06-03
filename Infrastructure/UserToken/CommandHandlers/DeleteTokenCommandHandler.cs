using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Infrastructure.Common;
using Infrastructure.UserToken.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UserToken.CommandHandlers
{
    public class DeleteTokenCommandHandler: IRequestHandler<DeleteTokenCommand, OperationResult<Unit>>
    {
        private readonly DatabaseContext _context;

        public DeleteTokenCommandHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteTokenCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var token = await _context.UserRegisterTokens.FirstOrDefaultAsync(e => e.Id == request.Id,
                cancellationToken);

            if (token is null)
            {
                return result.AddError("Token was not found");
            }

            _context.UserRegisterTokens.Remove(token);

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
