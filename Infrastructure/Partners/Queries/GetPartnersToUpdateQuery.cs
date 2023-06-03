using Infrastructure.Common;
using Infrastructure.Partners.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Partners.Queries
{
    public class GetPartnersToUpdateQuery : IRequest<EditPartnersVm>
    {
        public GetPartnersToUpdateQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
