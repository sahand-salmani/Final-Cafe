using System.Threading;
using System.Threading.Tasks;
using DataAccess.Database;
using Infrastructure.UserToken.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UserToken.QueryHandlers
{
    public class CheckTokenExistsQueryHandler : IRequestHandler<CheckTokenExistsQuery, bool>
    {
        private readonly DatabaseContext _context;

        public CheckTokenExistsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CheckTokenExistsQuery request, CancellationToken cancellationToken)
        {
            return await _context.UserRegisterTokens.AnyAsync(e => e.Token == request.Name, cancellationToken);
        }
    }
}
