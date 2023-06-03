using AutoMapper;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.BlackLists.Commands;
using Infrastructure.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace Infrastructure.BlackLists.CommandHandlers
{
    public class CreateBlackListCommandHandler : IRequestHandler<CreateBlackListCommand, OperationResult<int>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        

        public CreateBlackListCommandHandler(DatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OperationResult<int>> Handle(CreateBlackListCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var blackList = _mapper.Map<BlackList>(request.Model);

            await _context.BlackLists.AddAsync(blackList, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
