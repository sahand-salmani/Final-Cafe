using Infrastructure.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Partners.Commands
{
    public class DeletePartnersCommand : IRequest<OperationResult<int>>
    {
        public int Id { get; set; }

        public DeletePartnersCommand(int id)
        {
            Id = id;
        }
    }
}
