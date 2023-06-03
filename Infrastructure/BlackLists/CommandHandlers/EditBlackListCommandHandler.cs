using AutoMapper;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.BlackLists.Commands;
using Infrastructure.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.BlackLists.CommandHandlers
{
    public class EditBlackListCommandHandler : IRequestHandler<EditBlackListCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public EditBlackListCommandHandler(DatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OperationResult<int>> Handle(EditBlackListCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var blackList = await _context.BlackLists.AsNoTracking().SingleOrDefaultAsync(b => b.Id == request.Model.Id, cancellationToken);

            if( blackList is null)
            {
                return result.AddError("Black list was not found");
            }

            var updated = _mapper.Map<BlackList>(request.Model);

            _context.BlackLists.Update(updated);

            await _context.SaveChangesAsync(cancellationToken);

            result.Entity = updated.Id;

            return result;
        }
    }
}
