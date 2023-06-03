using Infrastructure.Common;
using Infrastructure.Partners.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Partners.Commands
{
    public class UpdatePartnersCommand:IRequest<OperationResult<int>>
    {
        public EditPartnersVm Model { get; set; }

        public UpdatePartnersCommand(EditPartnersVm model)
        {
            Model = model;
        }
    }
}
