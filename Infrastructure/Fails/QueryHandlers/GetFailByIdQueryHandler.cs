using System;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Fails.Queries;
using Infrastructure.Fails.ViewModels;
using MediatR;

namespace Infrastructure.Fails.QueryHandlers
{
    public class GetFailByIdQueryHandler : IRequestHandler<GetFailByIdQuery, GetFailsVm>
    {
        public Task<GetFailsVm> Handle(GetFailByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
