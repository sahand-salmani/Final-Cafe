using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Common;
using MediatR;

namespace Infrastructure.UserToken.Commands
{
    public class DeleteTokenCommand : IRequest<OperationResult<Unit>>
    {
        public DeleteTokenCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
