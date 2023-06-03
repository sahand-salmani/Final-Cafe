using Infrastructure.Common;
using Infrastructure.Partners.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Partners.Commands
{
    public class CreatePartnersCommand:IRequest<OperationResult<int>>
    {
        public CreatePartnersVm Model { get; set; }

        public CreatePartnersCommand(CreatePartnersVm model)
        {
            Model = model;
        }
    }
}
