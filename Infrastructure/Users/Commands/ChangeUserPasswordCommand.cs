using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Common;
using Infrastructure.Users.ViewModels;
using MediatR;

namespace Infrastructure.Users.Commands
{
    public class ChangeUserPasswordCommand : IRequest<OperationResult<string>>
    {
        public ChangeUserPasswordCommand(ChangePasswordVm model)
        {
            Model = model;
        }
        public ChangePasswordVm Model { get; set; }

    }
}
