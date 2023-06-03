using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Common;
using Infrastructure.UserToken.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UserToken.CommandHandlers
{
    public class CreateUserTokenCommandHandler : IRequestHandler<CreateUserTokenCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CreateUserTokenCommandHandler(DatabaseContext context,
                                             IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OperationResult<int>> Handle(CreateUserTokenCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var tokenExists =
                await _context.UserRegisterTokens.AnyAsync(e => e.Token == request.Model.Token, cancellationToken);

            if (tokenExists)
            {
                return result.AddError("Token already exists");
            }

            var role = await _context.Roles.SingleOrDefaultAsync(e => e.Id == request.Model.RoleId, cancellationToken);

            if (role is null)
            {
                return result.AddError("Specified role was not found");
            }

            var newToken = _mapper.Map<UserRegisterToken>(request.Model);

            await _context.UserRegisterTokens.AddAsync(newToken, cancellationToken);

            var persistenceResult = await _context.SaveChangesAsync(cancellationToken);

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            result.Entity = newToken.Id;

            return result;
        }
    }
}
