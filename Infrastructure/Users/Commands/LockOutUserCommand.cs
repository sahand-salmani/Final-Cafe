using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Common;
using MediatR;

namespace Infrastructure.Users.Commands
{
    public class LockOutUserCommand : IRequest<OperationResult<Unit>>
    {
        public string UserId { get; set; }
    }
}
